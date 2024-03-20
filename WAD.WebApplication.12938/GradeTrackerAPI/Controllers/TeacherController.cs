using AutoMapper;
using GradeTrackerAPI.Strategies;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        private readonly ILoginStrategy _loginStrategy;


        public TeacherController(ITeacherRepository teacherRepository, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILoginStrategy loginStrategy)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _loginStrategy = loginStrategy;
        }
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(TeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(teacherDto.User.EmailAddress);
            if (user != null)
            {
                ModelState.AddModelError("", "There is an account with the mentioned email");
                return StatusCode(500, ModelState);
            }
            var newUser = new AppUser()
            {
                Email = teacherDto.User.EmailAddress,
                UserName = teacherDto.User.EmailAddress,
                FirstName = teacherDto.User.FirstName,
                LastName = teacherDto.User.LastName,
                ProfileImage = teacherDto.User.ProfileImage
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, teacherDto.User.Password);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.Teacher);
            var teacher = _mapper.Map<Teacher>(teacherDto);
            teacher.User = await _userManager.FindByEmailAsync(teacherDto.User.EmailAddress);
            if (!await _teacherRepository.CreateTeacher(teacher))
                {
                    ModelState.AddModelError("", "Something went wrong while savin");
                    return StatusCode(500, ModelState);
                }

            return Ok("Successfully Registered");
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _loginStrategy.Login(Email, Password);
            if (result.IsSuccess)
            {
                return Ok(result.Teacher);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

        }

        [HttpGet("{TeacherId}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public IActionResult GetTeacher(int TeacherId)
        {
            if (!_teacherRepository.TeacherExists(TeacherId))
            {
                return NotFound();
            }
            var teacher = _mapper.Map<TeacherDto>(_teacherRepository.GetTeacher(TeacherId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(teacher);
        }
        [HttpGet("{TeacherId}/modules")]
        public IActionResult GetModulesByTeacher(int TeacherId)
        {
            if (!_teacherRepository.TeacherExists(TeacherId))
                return NotFound();

            var modules = _mapper.Map<List<ModuleDto>>(
                _teacherRepository.GetModulesByTeacher(TeacherId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(modules);
        }
        [HttpPut("{TeacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTeacher(int TeacherId, [FromBody] TeacherDto teacherUpdate)
        {
            if (teacherUpdate == null)
                return BadRequest(ModelState);

            if (TeacherId != teacherUpdate.Id)
                return BadRequest(ModelState);

            if (!_teacherRepository.TeacherExists(TeacherId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var teachermap = _mapper.Map<Teacher>(teacherUpdate);

            if (!await _teacherRepository.UpdateTeacher(teachermap))
            {
                ModelState.AddModelError("", "Something went wrong updating teacher");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpDelete("{TeacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTeacher(int TeacherId)
        {
            if (!_teacherRepository.TeacherExists(TeacherId))
            {
                return NotFound();
            }

            var teacherToDelete = _teacherRepository.GetTeacher(TeacherId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teacherRepository.DeleteTeacher(teacherToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Teacher");
            }

            return Ok("Sucessfully Deleted");
        }
    }
}

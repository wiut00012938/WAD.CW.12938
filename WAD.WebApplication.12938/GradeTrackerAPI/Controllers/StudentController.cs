﻿using AutoMapper;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> singInManager)
        {
            _userManager = userManager;
            _signInManager = singInManager;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(studentDto.User.EmailAddress);
            if (user != null)
            {
                ModelState.AddModelError("", "There is an account with the mentioned email");
                return StatusCode(500, ModelState);
            }
            var newUser = new AppUser()
            {
                Email = studentDto.User.EmailAddress,
                UserName = studentDto.User.EmailAddress,
                FirstName = studentDto.User.FirstName,
                LastName = studentDto.User.LastName,
                ProfileImage = studentDto.User.ProfileImage
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, studentDto.User.Password);
            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.Student);
            var student = _mapper.Map<Student>(studentDto);
            student.User = await _userManager.FindByEmailAsync(studentDto.User.EmailAddress);
            if (!await _studentRepository.CreateStudent(student))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Registered");
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                //User is found, check password
                var passworkCheck = await _userManager.CheckPasswordAsync(user, Password);
                if (passworkCheck)
                {
                    //Password corect, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, Password, false, false);
                    if (result.Succeeded)
                    {
                        return Ok(_mapper.Map<StudentDto>(_studentRepository.GetStudentByUser(user.UserName)));
                    }
                }
                ModelState.AddModelError("", "Wrong email or password");
                return StatusCode(500, ModelState);
            }
            return NotFound();
        }
        [HttpGet("{StudentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult GetStudent(int StudentId)
        {
            if (!_studentRepository.StudentExists(StudentId))
            {
                return NotFound();
            }
            var student = _mapper.Map<StudentDto>(_studentRepository.GetStudent(StudentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(student);
        }
        [HttpGet("{StudentId}/grades")]
        public IActionResult GetGradesByStudent(int StudentId)
        {
            if (!_studentRepository.StudentExists(StudentId))
                return NotFound();

            var grades = _mapper.Map<List<GradeDto>>(
                _studentRepository.GetGradesByStudent(StudentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(grades);
        }
        [HttpGet("{StudentId}/modules")]
        public IActionResult GetModulesByStudent(int StudentId)
        {
            if (!_studentRepository.StudentExists(StudentId))
                return NotFound();

            var modules = _mapper.Map<List<ModuleStudent>>(
                _studentRepository.GetModulesByStudent(StudentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(modules);
        }

        [HttpPut("{StudentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateStudent(int StudentId, [FromBody] StudentDto studentUpdate)
        {
            if (studentUpdate == null)
                return BadRequest(ModelState);

            if (StudentId != studentUpdate.Id)
                return BadRequest(ModelState);

            if (!_studentRepository.StudentExists(StudentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var studentmap = _mapper.Map<Student>(studentUpdate);

            if (!await _studentRepository.UpdateStudent(studentmap))
            {
                ModelState.AddModelError("", "Something went wrong updating Student");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpDelete("{StudentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStudent(int StudentId)
        {
            if (!_studentRepository.StudentExists(StudentId))
            {
                return NotFound();
            }

            var studentToDelete = _studentRepository.GetStudent(StudentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_studentRepository.DeleteStudent(studentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Student");
            }

            return Ok("Sucessfully Deleted");
        }
    }
}

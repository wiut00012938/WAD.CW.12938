using AutoMapper;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTeacher([FromBody] TeacherDto teacherCreate)
        {
            if (teacherCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teacher = _mapper.Map<Teacher>(teacherCreate);

            

            if (!_teacherRepository.CreateTeacher(teacher))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{TeacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTeacher(int TeacherId, [FromBody] TeacherDto teacherUpdate)
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

            if (!_teacherRepository.UpdateTeacher(teachermap))
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

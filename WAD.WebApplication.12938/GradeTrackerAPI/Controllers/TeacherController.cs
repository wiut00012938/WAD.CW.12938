using AutoMapper;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public TeacherController(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet("{TeacherId}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public IActionResult GetTeacher(int TeacherId)
        {
            if (_dbContext.Teachers.Any(r => r.Id == TeacherId) == null)
            {
                return NotFound();
            }
            var teacher = _mapper.Map<TeacherDto>(_dbContext.Teachers.Where(r => r.Id == TeacherId).Include(u => u.User).FirstOrDefault());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(teacher);
        }
        [HttpGet("{reviewerId}/modules")]
        public IActionResult GetModulesByTeacher(int TeacherId)
        {
            if (_dbContext.Teachers.Any(r => r.Id == TeacherId) == null)
                return NotFound();

            var modules = _mapper.Map<List<ModuleDto>>(
                _dbContext.Modules.Where(m => m.Teacher.Id == TeacherId).ToList());

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

            // Create an AppUser from the TeacherDto
            var appUser = teacherCreate.User;

            // Add the AppUser to the context and save changes
            _dbContext.Add(appUser);
            var appUserSaved = _dbContext.SaveChanges();

            if (appUserSaved <= 0)
            {
                return StatusCode(500, ModelState);
            }

            // Create a Teacher from the TeacherDto
            var teacher = _mapper.Map<Teacher>(teacherCreate);

            // Assign the AppUser's Id to the Teacher's AppUserId
            teacher.User = appUser;

            // Add the Teacher to the context and save changes
            _dbContext.Add(teacher);
            var teacherSaved = _dbContext.SaveChanges();

            if (teacherSaved <= 0)
            {
                // Rollback the AppUser creation if Teacher creation fails
                _dbContext.Remove(appUser);
                _dbContext.SaveChanges();

                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{TeacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReviewer(int TeacherId, [FromBody] TeacherDto teacherUpdate)
        {
            if (teacherUpdate == null)
                return BadRequest(ModelState);

            if (TeacherId != teacherUpdate.Id)
                return BadRequest(ModelState);

            if (!_dbContext.Teachers.Any(r => r.Id == TeacherId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var teachermap = _mapper.Map<Teacher>(teacherUpdate);
            _dbContext.Update(teachermap);
            var saved = _dbContext.SaveChanges();
            if (saved! > 0)
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
        public IActionResult DeleteReviewer(int TeacherId)
        {
            if (!_dbContext.Teachers.Any(r => r.Id == TeacherId))
            {
                return NotFound();
            }

            var teacherToDelete = _dbContext.Teachers.Where(t => t.Id == TeacherId).FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _dbContext.Remove(teacherToDelete);
            var saved = _dbContext.SaveChanges();

            if (saved !> 0)
            {
                ModelState.AddModelError("", "Something went wrong deleting Teacher");
            }

            return Ok("Sucessfully Deleted");
        }
    }
}

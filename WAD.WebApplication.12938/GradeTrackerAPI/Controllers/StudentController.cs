using AutoMapper;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
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
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStudent([FromBody] StudentDto studentCreate)
        {
            if (studentCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = _mapper.Map<Student>(studentCreate);



            if (!_studentRepository.CreateStudent(student))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{StudentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStudent(int StudentId, [FromBody] StudentDto studentUpdate)
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

            if (!_studentRepository.UpdateStudent(studentmap))
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

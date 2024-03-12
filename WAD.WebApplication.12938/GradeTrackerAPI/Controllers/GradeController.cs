using AutoMapper;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GradeController(IGradeRepository gradeRepository, IAssignmentRepository assignmentRepository,IStudentRepository studentRepository,IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _assignmentRepository = assignmentRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet("{GradeId}")]
        [ProducesResponseType(200, Type = typeof(Grade))]
        [ProducesResponseType(400)]
        public IActionResult GetGrade(int GradeId)
        {
            if (!_gradeRepository.GradeExists(GradeId))
            {
                return NotFound();
            }
            var grade = _mapper.Map<GradeDto>(_gradeRepository.GetGrade(GradeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(grade);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateGrade([FromQuery] int AssignmentId, [FromQuery] int StudentId,[FromBody] GradeDto GradeCreate)
        {
            if (GradeCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_assignmentRepository.AssignmentExists(AssignmentId))
            {
                return NotFound("Assignment not found");
            }

            var grade = _mapper.Map<Grade>(GradeCreate);
            grade.Assignment = _assignmentRepository.GetAssignment(AssignmentId);
            grade.Student = _studentRepository.GetStudent(StudentId);


            if (!_gradeRepository.CreateGrade(grade))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{GradeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGrade(int GradeId, [FromBody] GradeDto gradeUpdate)
        {
            if (gradeUpdate == null)
                return BadRequest(ModelState);

            if (GradeId != gradeUpdate.GradeId)
                return BadRequest(ModelState);

            if (!_gradeRepository.GradeExists(GradeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var gradeMap = _mapper.Map<Grade>(gradeUpdate);

            if (!_gradeRepository.UpdateGrade(gradeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Student");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpDelete("{GradeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGrade(int GradeId)
        {
            if (!_gradeRepository.GradeExists(GradeId))
            {
                return NotFound();
            }

            var studentToDelete = _gradeRepository.GetGrade(GradeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_gradeRepository.DeleteGrade(studentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Student");
            }

            return Ok("Sucessfully Deleted");
        }

    }
}

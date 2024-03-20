using AutoMapper;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public AssignmentController(IAssignmentRepository assignmentRepository, IModuleRepository moduleRepository,IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }
        [HttpGet("{AssignmentId}")]
        [ProducesResponseType(200, Type = typeof(Assignment))]
        [ProducesResponseType(400)]
        public IActionResult GetAssignment(int AssignmentId)
        {
            if (!_assignmentRepository.AssignmentExists(AssignmentId))
            {
                return NotFound();
            }
            var assignment = _mapper.Map<AssignmentDto>(_assignmentRepository.GetAssignment(AssignmentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(assignment);
        }
        [HttpGet("{AssignmentId}/grades")]
        public IActionResult GetGradesByAssignment(int AssignmentId)
        {
            if (!_assignmentRepository.AssignmentExists(AssignmentId))
                return NotFound();

            var grades = _assignmentRepository.GetGradesByAssignment(AssignmentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(grades);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAssignment([FromQuery] int ModuleId, [FromBody] AssignmentDto assignmentCreate)
        {
            if (assignmentCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var assignment = _mapper.Map<Assignment>(assignmentCreate);
            assignment.Module = _moduleRepository.GetModule(ModuleId);


            if (!_assignmentRepository.CreateAssignment(assignment))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpPut("{AssignmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAssignment(int AssignmentId, [FromBody] AssignmentDto assignmentUpdate)
        {
            if (assignmentUpdate == null)
                return BadRequest(ModelState);

            if (AssignmentId != assignmentUpdate.AssignmentId)
                return BadRequest(ModelState);

            if (!_assignmentRepository.AssignmentExists(AssignmentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var assignmentMap = _mapper.Map<Assignment>(assignmentUpdate);

            if (!_assignmentRepository.UpdateAssignment(assignmentMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Student");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{AssignmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAssignment(int AssignmentId)
        {
            if (!_assignmentRepository.AssignmentExists(AssignmentId))
            {
                return NotFound();
            }

            var assignmentToDelete = _assignmentRepository.GetAssignment(AssignmentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_assignmentRepository.DeleteAssignment(assignmentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Student");
            }

            return NoContent();
        }
    }
}

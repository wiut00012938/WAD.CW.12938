using AutoMapper;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : Controller
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public ModuleController(IModuleRepository moduleRepository, ITeacherRepository teacherRepository,IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        [HttpGet("{ModuleId}")]
        [ProducesResponseType(200, Type = typeof(Module))]
        [ProducesResponseType(400)]
        public IActionResult GetModule(int ModuleId)
        {
            if (!_moduleRepository.ModuleExists(ModuleId))
            {
                return NotFound();
            }
            var module = _mapper.Map<ModuleDto>(_moduleRepository.GetModule(ModuleId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(module);
        }
        [HttpGet("{ModuleId}/assignments")]
        public IActionResult GetAssignmentsByModule(int ModuleId)
        {
            if (!_moduleRepository.ModuleExists(ModuleId))
                return NotFound();

            var assignments = _mapper.Map<List<AssignmentDto>>(
                _moduleRepository.GetAssignmentsByModule(ModuleId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(assignments);
        }
        [HttpGet("{ModuleId}/students")]
        public IActionResult GetStudentsByModule(int ModuleId)
        {
            if (!_moduleRepository.ModuleExists(ModuleId))
                return NotFound();

            var modules = _mapper.Map<List<ModuleStudent>>(
                _moduleRepository.GetStudentsByModule(ModuleId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(modules);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateModule([FromQuery] int TeacherId, [FromBody] ModuleDto moduleCreate)
        {
            if (moduleCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var module = _mapper.Map<Module>(moduleCreate);
            module.Teacher = _teacherRepository.GetTeacher(TeacherId);
            module.Teacher.LeadingModulesNum = module.Teacher.LeadingModulesNum + 1;

            if (!_teacherRepository.UpdateTeacher(module.Teacher))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            if (!_moduleRepository.CreateModule(module))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{ModuleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateModule(int ModuleId, [FromBody] ModuleDto moduleUpdate)
        {
            if (moduleUpdate == null)
                return BadRequest(ModelState);

            if (ModuleId != moduleUpdate.ModuleId)
                return BadRequest(ModelState);

            if (!_moduleRepository.ModuleExists(ModuleId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var moduleMap = _mapper.Map<Module>(moduleUpdate);

            if (!_moduleRepository.UpdateModule(moduleMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Module");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpDelete("{ModuleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteModule(int ModuleId)
        {
            if (!_moduleRepository.ModuleExists(ModuleId))
            {
                return NotFound();
            }

            var moduleToDelete = _moduleRepository.GetModule(ModuleId);

            moduleToDelete.Teacher.LeadingModulesNum = moduleToDelete.Teacher.LeadingModulesNum  + 1;

            if (!_teacherRepository.UpdateTeacher(moduleToDelete.Teacher))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_moduleRepository.DeleteModule(moduleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Module");
            }

            return Ok("Sucessfully Deleted");
        }
        [HttpDelete("/DeleteModulesByTeacher/{TeacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReviewsByReviewer(int TeacherId)
        {
            if (!_teacherRepository.TeacherExists(TeacherId))
                return NotFound();

            var modulesToDelete = _teacherRepository.GetModulesByTeacher(TeacherId).ToList();
            var teacher = _teacherRepository.GetTeacher(TeacherId);
            teacher.LeadingModulesNum = 0;

            if (!_teacherRepository.UpdateTeacher(teacher))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_moduleRepository.DeleteModules(modulesToDelete))
            {
                ModelState.AddModelError("", "error deleting reviews");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}

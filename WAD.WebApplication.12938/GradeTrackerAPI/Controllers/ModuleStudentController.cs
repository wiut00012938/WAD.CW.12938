using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleStudentController : Controller
    {
        private readonly IModuleStudentRepository _moduleStudentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IModuleRepository _moduleRepository;

        public ModuleStudentController(IModuleStudentRepository moduleStudentRepository, IStudentRepository studentRepository, IModuleRepository moduleRepository)
        {
            _moduleStudentRepository = moduleStudentRepository;
            _studentRepository = studentRepository;
            _moduleRepository = moduleRepository;
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult IncludeStudentToModule([FromQuery] int ModuleId, [FromQuery] int StudentId)
        {
            if (!_moduleRepository.ModuleExists(ModuleId))
                return NotFound("Module Not Found");

            if (!_studentRepository.StudentExists(StudentId))
            {
                return NotFound("Student Not Found");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_moduleStudentRepository.IncludeStudentToModule(StudentId, ModuleId))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStudentFromModule([FromQuery] int ModuleId, [FromQuery] int StudentId)
        {
            if (!_moduleRepository.ModuleExists(ModuleId))
                return NotFound("Module Not Found");

            if (!_studentRepository.StudentExists(StudentId))
            {
                return NotFound("Student Not Found");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var moduleStudent = _moduleStudentRepository.GetModelStudent(StudentId, ModuleId);

            if (!_moduleStudentRepository.DeleteStudentFromModule(moduleStudent))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("/DeleteStudentsFromModule/{ModuleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStudentFromModule(int ModuleId)
        {
            if (!_moduleRepository.ModuleExists(ModuleId))
                return NotFound();

            var studentsToDelete = _moduleStudentRepository.GetStudentsFromModule(ModuleId).ToList();
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_moduleStudentRepository.DeleteStudentsFromModule(studentsToDelete))
            {
                ModelState.AddModelError("", "error deleting reviews");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}

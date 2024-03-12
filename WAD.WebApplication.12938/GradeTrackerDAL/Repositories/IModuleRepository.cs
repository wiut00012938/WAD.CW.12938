using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public interface IModuleRepository
    {
        Module GetModule(int id);
        ICollection<ModuleStudent> GetStudentsByModule(int studentId);
        ICollection<Assignment> GetAssignmentsByModule(int moduleId);
        bool ModuleExists(int moduleId);
        bool CreateModule(Module module);
        bool UpdateModule(Module module);
        bool DeleteModule(Module module);
        bool DeleteModules(List<Module> modules);
        bool Save();
    }
}

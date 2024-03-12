using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public interface IModuleStudentRepository
    {
        ModuleStudent GetModelStudent(int StudentId, int ModuleId);
        ICollection<ModuleStudent> GetStudentsFromModule(int ModuleId);
        bool IncludeStudentToModule(int StudentId, int ModuleId);
        bool DeleteStudentFromModule(ModuleStudent moduleStudent);
        bool DeleteStudentsFromModule(List<ModuleStudent> moduleStudents);
        bool Save();
    }
}

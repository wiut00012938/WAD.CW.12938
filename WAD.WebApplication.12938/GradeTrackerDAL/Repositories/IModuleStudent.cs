using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public interface IModuleStudent
    {
        bool IncludeStudentToModule(int studentId, int moduleId);
        bool DeleteStudentFromModule(int studentId, int moduleId);
        bool IncludeStudentsToModule(List<int> studentIds, int moduleId);
        bool DeleteStudentsFromModule(List<int> studentIds, int moduleId);
        bool Save();
    }
}

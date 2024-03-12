using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public interface IAssignmentRepository
    {
        Assignment GetAssignment(int id);
        Module GetModuleByAssignment(int AssignmentId);
        ICollection<Grade> GetGradesByAssignment(int AssignmentId);
        bool AssignmentExists(int AssignmentId);
        bool CreateAssignment(Assignment assignment);
        bool UpdateAssignment(Assignment assignment);
        bool DeleteAssignment(int AssignmentId);
        bool Save();
    }
}

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
        ICollection<Grade> GetGradesByAssignment(int AssignmentId);
        bool AssignmentExists(int AssignmentId);
        bool CreateAssignment(Assignment assignment);
        bool UpdateAssignment(Assignment assignment);
        bool DeleteAssignment(Assignment assignment);
        bool Save();
    }
}

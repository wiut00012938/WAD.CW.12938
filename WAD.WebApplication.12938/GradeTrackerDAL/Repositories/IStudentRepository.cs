using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        ICollection<Module> GetModulesByStudent(int StudentId);
        ICollection<Grade> GetGradesByStudent(int StudentId);
        bool StudentExists(int StudentId);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool Save();
    }
}

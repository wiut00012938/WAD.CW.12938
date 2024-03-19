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
        ICollection<Student> GetAllStudents();
        Student GetStudent(int id);
        Student GetStudentByUser(string username);
        ICollection<ModuleStudent> GetModulesByStudent(int StudentId);
        ICollection<Grade> GetGradesByStudent(int StudentId);
        bool StudentExists(int StudentId);
        Task<bool> CreateStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool Save();
        Task<bool> SaveAsync();
    }
}

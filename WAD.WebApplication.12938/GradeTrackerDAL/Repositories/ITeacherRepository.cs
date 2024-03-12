using GradeTrackerDAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public interface ITeacherRepository
    {
        Teacher GetTeacher(int id);
        ICollection<Module> GetModulesByTeacher(int TeacherId);
        bool TeacherExists(int TeacherId);
        bool CreateTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);
        bool Save();
    }
}

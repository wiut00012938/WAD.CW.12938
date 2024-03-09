using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Models
{
    public class Student
    {
        public int Id { get; set; } //Primary Key for Student
        public int EnrolledModulesNum { get; set; }
        public string UserId { get; set; } //Foreign Key for AppUser
        //Navigation property for Student
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Module> EnrolledModules { get; set; }
        public AppUser User { get; set; }
    }
}

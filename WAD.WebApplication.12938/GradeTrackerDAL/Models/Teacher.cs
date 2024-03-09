using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Models
{
    public class Teacher
    {
        public int Id { get; set; } //Primary Key for Teacher
        public string TeacherBackground { get; set; }
        public int LeadingModulesNum { get; set; }
        public string UserId { get; set; } //Foreign Key for AppUser

        //Navigation property
        public ICollection<Module> Modules { get; set; }
        public AppUser User { get; set; }
    }
}

using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.DTO
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string TeacherBackground { get; set; }
        public UserDto User { get; set; }
    }
}

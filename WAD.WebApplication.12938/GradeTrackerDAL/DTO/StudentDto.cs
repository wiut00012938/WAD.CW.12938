using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.DTO
{
    public class StudentDto
    {
        public int Id { get; set; } //Primary Key for Student
        public int EnrolledModulesNum { get; set; }
        public UserDto User { get; set; }
    }
}

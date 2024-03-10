using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Models
{
    public class ModuleStudent
    {
        public int ModuleId { get; set; }
        public int StudentId { get; set;}
        public Module Module { get; set; }
        public Student Student { get; set; }
    }
}

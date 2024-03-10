using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string? AssignmentDescription { get; set; }
        public DateTime CreatedDate { get; set; }
  
        public Module Module { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}

using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.DTO
{
    public class GradeDto
    {
        public int GradeId { get; set; }
        public int Score { get; set; }
        public string? Feedback { get; set; }
    }
}

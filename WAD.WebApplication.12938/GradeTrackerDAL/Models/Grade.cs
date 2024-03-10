﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int Score { get; set; }
        public string? Feedback { get; set; }
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
    }
}

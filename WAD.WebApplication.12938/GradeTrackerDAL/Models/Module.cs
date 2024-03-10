﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Models
{
    public class Module
    {
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }
        public string? ModuleDescription { get; set; }

        //Navigation to Teacher and Assignment Tables
        public Teacher Teacher { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ModuleStudent> ModuleStudents { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace GradeTrackerAPI.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string? AssignmentDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModuleId { get; set; }
        //Navigation properities for Assigment Table
        public Module Module { get; set; }
        public ICollection<Grade> Grades { get; set;}

    }
}
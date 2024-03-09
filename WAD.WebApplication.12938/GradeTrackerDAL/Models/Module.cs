namespace GradeTrackerAPI.Models
{
    public class Module
    {
        public int ModuleId { get; set; }

        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public int TeacherId { get; set; }

        //Navigation to Teacher and Assignment Tables
        public Teacher Teacher { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

using GradeTrackerDAL.DTO;

namespace GradeTrackerAPI.Strategies
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public TeacherDto Teacher { get; set; }
        public StudentDto Student { get; set; }
    }
}

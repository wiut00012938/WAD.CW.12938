using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImage { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Pawword do not match")]
        public string ConfirmPassword { get; set; }

    }
}

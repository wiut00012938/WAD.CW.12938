
using AutoMapper;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using GradeTrackerDAL.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Web.Http.ModelBinding;

namespace GradeTrackerAPI.Strategies
{
    public class StudentLoginStrategy : ILoginStrategy
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public StudentLoginStrategy(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }
        
        public async Task<LoginResult> Login(string email, string password)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                //User is found, check password
                var passworkCheck = await _userManager.CheckPasswordAsync(user, password);
                if (passworkCheck)
                {
                    //Password corect, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                    if (result.Succeeded)
                    {
                        var student = _studentRepository.GetStudentByUser(user.UserName);
                        var teacher = _teacherRepository.GetTeacherByUser(user.UserName);
                        var studentDto = _mapper.Map<StudentDto>(student);
                        var teacherdDto = _mapper.Map<TeacherDto>(teacher);
                        return new LoginResult { IsSuccess = true, Student = studentDto , Teacher = teacherdDto};
                    }
                }
                return new LoginResult { IsSuccess = false, ErrorMessage = "Invalid password"};
            }
            return new LoginResult { IsSuccess = false, ErrorMessage = "Not Found"};
        }
    }
}

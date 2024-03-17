using AutoMapper;
using GradeTrackerDAL.DTO;
using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<Module, ModuleDto>();
            CreateMap<ModuleDto, Module>();
            CreateMap<UserDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Grade, GradeDto>();
            CreateMap<GradeDto, Grade>();
            CreateMap<Assignment, AssignmentDto>();
            CreateMap<AssignmentDto, Assignment>();
        }
    }
}

using AutoMapper;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public class ModuleStudentRepository : IModuleStudentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ModuleStudentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool DeleteStudentFromModule(ModuleStudent moduleStudent)
        {
            _context.Remove(moduleStudent);
            return Save();
        }

        public bool DeleteStudentsFromModule(List<ModuleStudent> moduleStudents)
        {
            _context.Remove(moduleStudents);
            return Save();
        }

        public ModuleStudent GetModelStudent(int StudentId, int ModuleId)
        {
            return _context.ModuleStudents.Where(a => a.StudentId == StudentId).Where(m => m.ModuleId == ModuleId).FirstOrDefault();
        }

        public ICollection<ModuleStudent> GetStudentsFromModule(int ModuleId)
        {
            return _context.ModuleStudents.Where(m => m.ModuleId == ModuleId).ToList();
        }

        public bool IncludeStudentToModule(int StudentId, int ModuleId)
        {
            var student = _context.Students.Where(s => s.Id == StudentId).FirstOrDefault();
            var module = _context.Modules.Where(m => m.ModuleId == ModuleId).FirstOrDefault();

            var ModuleStudent = new ModuleStudent()
            {
                Student = student,
                Module = module
            };
            _context.Add(ModuleStudent);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

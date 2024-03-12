using AutoMapper;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.Migrations;
using GradeTrackerDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeacherRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateTeacher(Teacher teacher)
        {
            _context.Add(teacher);
            return Save();
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _context.Remove(teacher);
            _context.Remove(teacher.User);
            return Save();
        }

        public ICollection<Module> GetModulesByTeacher(int TeacherId)
        {
            return _context.Modules.Where(m => m.Teacher.Id == TeacherId).ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return _context.Teachers.Where(r => r.Id == id).Include(u => u.User).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true: false;
        }

        public bool TeacherExists(int TeacherId)
        {
            return _context.Teachers.Any(t => t.Id == TeacherId);
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _context.Update(teacher);
            return Save();
        }
    }
}

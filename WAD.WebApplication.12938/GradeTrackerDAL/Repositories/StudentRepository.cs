using AutoMapper;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteStudent(Student student)
        {
            _context.Remove(student);
            _context.Remove(student.User);
            return Save();
        }

        public ICollection<Grade> GetGradesByStudent(int StudentId)
        {
            return _context.Grades.Where(s => s.Student.Id == StudentId).Include(a => a.Assignment).Include(m => m.Assignment.Module).ToList();
        }

        public ICollection<ModuleStudent> GetModulesByStudent(int StudentId)
        {
            return _context.ModuleStudents.Where(s => s.Student.Id == StudentId).Include(m => m.Module).ToList();
        }   

        public Student GetStudent(int id)
        {
            return _context.Students.Where(s => s.Id == id).Include(u => u.User).FirstOrDefault();
        }

        public Student GetStudentByUser(string username)
        {
            return _context.Students.Where(r => r.User.UserName == username).Include(u => u.User).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0; throw new NotImplementedException();
        }

        public bool StudentExists(int StudentId)
        {
            return _context.Students.Any(s => s.Id == StudentId);
        }


        public async Task<bool> CreateStudent(Student student)
        {
            _context.Add(student);
            return await SaveAsync();
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            _context.Update(student);
            return await SaveAsync();
        }

        public ICollection<Student> GetAllStudents()
        {
            return _context.Students.Include(u => u.User).ToList();
        }
    }
}

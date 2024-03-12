using AutoMapper;
using GradeTrackerDAL.Data;
using GradeTrackerDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ModuleRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateModule(Module module)
        {
            _context.Add(module);
            return Save();
        }

        public bool DeleteModule(Module module)
        {
            _context.Remove(module);
            return Save();
        }

        public bool DeleteModules(List<Module> modules)
        {
            _context.Remove(modules);
            return Save();
        }

        public ICollection<Assignment> GetAssignmentsByModule(int moduleId)
        {
            return _context.Assignments.Where(a => a.Module.ModuleId == moduleId).ToList();
        }

        public Module GetModule(int id)
        {
            return _context.Modules.Where(m => m.ModuleId == id).Include(t => t.Teacher).FirstOrDefault();
        }

        public ICollection<ModuleStudent> GetStudentsByModule(int studentId)
        {
            return _context.ModuleStudents.Where(m => m.Student.Id  == studentId).ToList();
        }

        public bool ModuleExists(int moduleId)
        {
            return _context.Modules.Any(m => m.ModuleId == moduleId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateModule(Module module)
        {
            _context.Update(module);
            return Save();
        }
    }
}

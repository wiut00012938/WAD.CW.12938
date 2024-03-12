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
    public class GradeRepository : IGradeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GradeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateGrade(Grade grade)
        {
            _context.Add(grade);
            return Save();
        }

        public bool DeleteGrade(Grade grade)
        {
            _context.Remove(grade);
            return Save();
        }

        public Grade GetGrade(int id)
        {
            return _context.Grades.Where(g => g.GradeId == id).Include(s => s.Student).Include(a => a.Assignment).FirstOrDefault();
        }

        public bool GradeExists(int GradeId)
        {
            return _context.Grades.Any(g => g.GradeId == GradeId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGrade(Grade grade)
        {
            _context.Update(grade);
            return Save();
        }
    }
}

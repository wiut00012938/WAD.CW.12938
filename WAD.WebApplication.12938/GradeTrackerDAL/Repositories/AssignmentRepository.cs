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
    public class AssignmentRepository: IAssignmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AssignmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AssignmentExists(int AssignmentId)
        {
            return _context.Students.Any(a => a.Id == AssignmentId);
        }

        public bool CreateAssignment(Assignment assignment)
        {
            _context.Add(assignment);
            return Save();
        }

        public bool DeleteAssignment(Assignment assignment)
        {
            _context.Remove(assignment);
            return Save();
        }

        public Assignment GetAssignment(int id)
        {
            return _context.Assignments.Where(a => a.AssignmentId == id).Include(g => g.Grades).FirstOrDefault();
        }

        public ICollection<Grade> GetGradesByAssignment(int AssignmentId)
        {
            return _context.Grades.Where(a => a.Assignment.AssignmentId == AssignmentId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAssignment(Assignment assignment)
        {
            _context.Update(assignment);
            return Save();
        }
    }
}

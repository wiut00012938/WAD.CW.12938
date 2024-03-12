using GradeTrackerDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Repositories
{
    public interface IGradeRepository
    {
        Grade GetGrade(int id);
        bool GradeExists(int GradeId);
        bool CreateGrade(Grade grade);
        bool UpdateGrade(Grade grade);
        bool DeleteGrade(Grade grade);
        bool Save();
    }
}

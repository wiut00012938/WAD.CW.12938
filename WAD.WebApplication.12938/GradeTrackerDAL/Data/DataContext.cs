using GradeTrackerDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTrackerDAL.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleStudent> ModuleStudents { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ModuleStudent>()
                .ToTable("ModuleStudents");

            modelBuilder.Entity<ModuleStudent>()
                .HasKey(mc => new { mc.ModuleId, mc.StudentId });

            modelBuilder.Entity<ModuleStudent>()
                .HasOne(mc => mc.Module)
                .WithMany(m => m.ModuleStudents)  
                .HasForeignKey(c => c.ModuleId);

            modelBuilder.Entity<ModuleStudent>()
                .HasOne(mc => mc.Student)
                .WithMany(s => s.ModuleStudents)
                .HasForeignKey(c => c.StudentId);

            modelBuilder.Entity<Module>()
                .HasOne(m => m.Teacher)
                .WithMany(t => t.Modules)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Module)
                .WithMany(m => m.Assignments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Assignment)
                .WithMany(a => a.Grades)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

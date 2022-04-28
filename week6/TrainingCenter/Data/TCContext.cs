using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Models;

namespace TrainingCenter.Data
{
    public class TCContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseGrade> CourseGrades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonGrade> LessonGrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=TrainingCenter; Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne(c => c.Teacher).WithMany(t => t.Courses).HasForeignKey(c => c.TeacherId);
            modelBuilder.Entity<Course>().HasMany(c => c.Students).WithMany(s => s.Courses);
            modelBuilder.Entity<Lesson>().HasOne(l => l.Course).WithMany(c => c.Lessons).HasForeignKey(l => l.CourseId);
            modelBuilder.Entity<Lesson>().HasMany(l => l.Students).WithMany(s => s.Lessons);
            modelBuilder.Entity<LessonGrade>().HasOne(g => g.Student).WithMany(s => s.LessonGrades).HasForeignKey(g => g.StudentId);
            modelBuilder.Entity<LessonGrade>().HasOne(g => g.Lesson).WithMany(l => l.Grades).HasForeignKey(g => g.LessonId);
            modelBuilder.Entity<CourseGrade>().HasOne(g => g.Student).WithMany(s => s.CourseGrades).HasForeignKey(g => g.CourseId);
            modelBuilder.Entity<CourseGrade>().HasOne(g => g.Course).WithMany(c => c.Grades).HasForeignKey(g => g.CourseId);
        }
    }
}

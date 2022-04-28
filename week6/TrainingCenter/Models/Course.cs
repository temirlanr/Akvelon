using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Data;

namespace TrainingCenter.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<CourseGrade> Grades { get; set; }
        public List<Lesson> Lessons { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }

        private readonly TCContext _context;

        public Course(TCContext context)
        {
            _context = context;
        }

        public void AddCourse()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            _context.Courses.Add(this);
            _context.SaveChanges();
        }

        public void DeleteCourse()
        {
            if (this == null)
            {
                return;
            }

            _context.Courses.Remove(this);
            _context.SaveChanges();
        }

        public void UpdateCourse()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            _context.Courses.Update(this);
            _context.SaveChanges();
        }
    }
}
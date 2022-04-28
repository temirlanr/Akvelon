using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Data;

namespace TrainingCenter.Models
{
    public class CourseGrade
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        [Required]
        public double Grade { get; set; }

        private readonly TCContext context;

        public CourseGrade(int grade, TCContext context)
        {
            Grade = grade;
            this.context = context;
            AddCourseGrade();
        }

        private void AddCourseGrade()
        {
            if (this == null)
            {
                return;
            }

            if (Grade < 0 && Grade > 100)
            {
                return;
            }

            context.CourseGrades.Add(this);
            context.SaveChanges();
        }

        private CourseGrade GetCourseGrade()
        {
            return context.CourseGrades.FirstOrDefault(c => c.Id == Id);
        }

        private IEnumerable<CourseGrade> GetCourseGrades()
        {
            return context.CourseGrades.ToList();
        }

        private void DeleteCourseGrade()
        {
            if (this == null)
            {
                return;
            }

            context.CourseGrades.Remove(this);
            context.SaveChanges();
        }

        private void UpdateCourseGrade()
        {
            if (this == null)
            {
                return;
            }

            if (Grade < 0 && Grade > 100)
            {
                return;
            }

            context.CourseGrades.Update(this);
            context.SaveChanges();
        }
    }
}

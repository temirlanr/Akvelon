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

        private readonly TCContext context;

        public Course(string name, int teacherId, TCContext context)
        {
            Name = name;
            TeacherId = teacherId;
            this.context = context;
            AddCourse();
        }

        public void ChangeTeacher(int teacherId)
        {
            TeacherId = teacherId;
            UpdateCourse();
        }

        private void AddCourse()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Courses.Add(this);
            context.SaveChanges();
        }

        private Course GetCourse()
        {
            return context.Courses.FirstOrDefault(c => c.Id == Id);
        }

        private IEnumerable<Course> GetCourses()
        {
            return context.Courses.ToList();
        }

        private void DeleteCourse()
        {
            if (this == null)
            {
                return;
            }

            context.Courses.Remove(this);
            context.SaveChanges();
        }

        private void UpdateCourse()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Courses.Update(this);
            context.SaveChanges();
        }
    }
}
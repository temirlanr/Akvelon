using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Data;

namespace TrainingCenter.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseGrade> CourseGrades { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<LessonGrade> LessonGrades { get; set; }

        private readonly TCContext context;

        public Student(string name, TCContext context)
        {
            Name = name;
            this.context = context;
            AddStudent();
        }

        private void AddStudent()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Students.Add(this);
            context.SaveChanges();
        }

        private Student GetStudent()
        {
            return context.Students.FirstOrDefault(c => c.Id == Id);
        }

        private IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList();
        }

        private void DeleteStudent()
        {
            if (this == null)
            {
                return;
            }

            context.Students.Remove(this);
            context.SaveChanges();
        }

        private void UpdateStudent()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Students.Update(this);
            context.SaveChanges();
        }
    }
}
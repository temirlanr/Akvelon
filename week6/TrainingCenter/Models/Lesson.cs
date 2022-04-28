using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Data;

namespace TrainingCenter.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<LessonGrade> Grades { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }

        private readonly TCContext context;

        public Lesson(string name, TCContext context)
        {
            Name = name;
            this.context = context;
            AddLesson();
        }

        private void AddLesson()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Lessons.Add(this);
            context.SaveChanges();
        }

        private Lesson GetLesson()
        {
            return context.Lessons.FirstOrDefault(c => c.Id == Id);
        }

        private IEnumerable<Lesson> GetLessons()
        {
            return context.Lessons.ToList();
        }

        private void DeleteLesson()
        {
            if (this == null)
            {
                return;
            }

            context.Lessons.Remove(this);
            context.SaveChanges();
        }

        private void UpdateLesson()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Lessons.Update(this);
            context.SaveChanges();
        }
    }
}
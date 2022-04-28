using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Data;

namespace TrainingCenter.Models
{
    public class LessonGrade
    {
        [Key]
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }
        [Required]
        public double Grade { get; set; }

        private readonly TCContext context;

        public LessonGrade(int grade, TCContext context)
        {
            Grade = grade;
            this.context = context;
            AddLessonGrade();
        }

        private void AddLessonGrade()
        {
            if (this == null)
            {
                return;
            }

            if (Grade < 0 && Grade > 100)
            {
                return;
            }

            context.LessonGrades.Add(this);
            context.SaveChanges();
        }

        private LessonGrade GetLessonGrade()
        {
            return context.LessonGrades.FirstOrDefault(c => c.Id == Id);
        }

        private IEnumerable<LessonGrade> GetLessonGrades()
        {
            return context.LessonGrades.ToList();
        }

        private void DeleteLessonGrade()
        {
            if (this == null)
            {
                return;
            }

            context.LessonGrades.Remove(this);
            context.SaveChanges();
        }

        private void UpdateLessonGrade()
        {
            if (this == null)
            {
                return;
            }

            if (Grade < 0 && Grade > 100)
            {
                return;
            }

            context.LessonGrades.Update(this);
            context.SaveChanges();
        }
    }
}

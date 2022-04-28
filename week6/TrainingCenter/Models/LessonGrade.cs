using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Models
{
    public class LessonGrade
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Lesson Lesson { get; set; }
        public int LessonId { get; set; }
        public double Grade { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<LessonGrade> Grades { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
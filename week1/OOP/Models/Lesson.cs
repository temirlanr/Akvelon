using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Lesson
    {
        public string LessonName { get; set; }
        public Dictionary<Student, int?> LessonStudents { get; set; } = new Dictionary<Student, int?>();
        public Course? LessonCourse { get; set; }
    }
}

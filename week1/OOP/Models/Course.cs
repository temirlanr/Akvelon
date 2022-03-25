using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Course
    {
        public string CourseName { get; set; }
        public Dictionary<Student, int?> CourseStudents { get; set; } = new Dictionary<Student, int?>();
        public List<Lesson> CourseLessons { get; set; } = new List<Lesson>();
        public Teacher? CourseTeacher { get; set; }
    }
}

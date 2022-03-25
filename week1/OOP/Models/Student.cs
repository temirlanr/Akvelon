using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Student
    {
        public string StudentName { get; set; }
        public List<Course> StudentCourses { get; set; } = new List<Course>();
        public List<Lesson> StudentLessons { get; set; } = new List<Lesson>();
    }
}

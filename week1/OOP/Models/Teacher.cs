using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Teacher
    {
        public string TeacherName { get; set; }
        public List<Course> TeacherCourses { get; set; } = new List<Course>();
    }
}

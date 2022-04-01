using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Lesson
    {
        private string lessonName;
        public string LessonName
        {
            get
            {
                return lessonName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name cannot be empty");
                }

                lessonName = value;
            }
        }
        private Dictionary<Student, double> students;
        public Dictionary<Student, double> LessonStudents { get { return students; } }
        private Course course;
        public Course LessonCourse { get { return course; } }

        public Lesson(string name, Course course)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name cannot be empty");
            }

            lessonName = name;
            students = new Dictionary<Student, double>();
            
            foreach(var item in course.CourseStudents)
            {
                students.Add(item.Key, default);
            }

            this.course = course;
            course.CourseLessons.Add(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Student
    {
        private string studentName;
        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name cannot be empty");
                }

                studentName = value;
            }
        }
        private List<Course> courses;
        public List<Course> StudentCourses { get { return courses; } }
        private List<Lesson> lessons;
        public List<Lesson> StudentLessons { get { return lessons; } }

        public Student(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name cannot be empty");
            }

            studentName = name;
            courses = new List<Course>();
            lessons = new List<Lesson>();
        }

        public void AddToCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course null");
            }

            course.CourseStudents.Add(this, default);
            
            foreach(var item in course.CourseLessons)
            {
                item.LessonStudents.Add(this, default);
            }

            courses.Add(course);
            lessons = course.CourseLessons;
        }

        public void RemoveFromCourse(Course course)
        {
            if (!courses.Contains(course))
            {
                return;
            }

            if (course.CourseStudents.Count > 0)
            {
                course.CourseStudents.Remove(this);

                foreach (var item in course.CourseLessons)
                {
                    item.LessonStudents.Remove(this);
                }
            }

            courses.Remove(course);
            lessons = new List<Lesson>();
        }
    }
}

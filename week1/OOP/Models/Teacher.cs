using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Teacher
    {
        private string teacherName;
        public string TeacherName
        {
            get
            {
                return teacherName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name cannot be empty");
                }

                teacherName = value;
            }
        }
        private List<Course> courses;
        public List<Course> TeacherCourses { get { return courses; } }

        public Teacher(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name cannot be empty");
            }

            teacherName = name;
            courses = new List<Course>();
        }

        public void GiveCourseScore(Student student, Course course)
        {
            if (!courses.Contains(course))
            {
                return;
            }

            if (!course.CourseStudents.ContainsKey(student))
            {
                return;
            }

            if (student == null)
            {
                throw new ArgumentNullException("Student null");
            }

            if (course == null)
            {
                throw new ArgumentNullException("Course null");
            }

            double sum = 0;

            foreach(var item in course.CourseLessons)
            {
                sum = sum + item.LessonStudents[student];
            }

            course.CourseStudents[student] = sum / course.CourseLessons.Count;
        }

        public void GiveLessonScore(Student student, Lesson lesson, double score)
        {
            if (!courses.Contains(lesson.LessonCourse))
            {
                return;
            }

            if (!lesson.LessonStudents.ContainsKey(student))
            {
                return;
            }

            if (student == null)
            {
                throw new ArgumentNullException("Student null");
            }

            if (lesson == null)
            {
                throw new ArgumentNullException("Lesson null");
            }

            if (score < 0 && score > 100)
            {
                throw new Exception("Score not in range 0-100");
            }

            lesson.LessonStudents[student] = score;
        }
    }
}

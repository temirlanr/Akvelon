using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Course
    {
        private string courseName;
        public string CourseName { 
            get 
            { 
                return courseName; 
            } 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name cannot be empty");
                }

                courseName = value; 
            } 
        }
        private Dictionary<Student, double> students;
        public Dictionary<Student, double> CourseStudents { get { return students; } }
        private List<Lesson> lessons;
        public List<Lesson> CourseLessons { get { return lessons; } }
        private Teacher teacher;
        public Teacher CourseTeacher { get { return teacher; } set { teacher = value; } }

        public Course(string name, Teacher teacher)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name cannot be empty");
            }

            courseName = name;
            students = new Dictionary<Student, double>();
            lessons = new List<Lesson>();
            this.teacher = teacher;
            teacher.TeacherCourses.Add(this);
        }

        public void ChangeTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException("Teacher null");
            }

            this.teacher.TeacherCourses.Remove(this);
            this.teacher = teacher;
            this.teacher.TeacherCourses.Add(this);
        }
    }
}

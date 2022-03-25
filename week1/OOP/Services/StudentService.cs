using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Services
{
    public interface IStudentService
    {
        bool AddStudentToCourse(Course course, Student student);
        bool RemoveStudentFromCourse(Course course, Student student);
    }

    public class StudentService : IStudentService
    {
        public bool AddStudentToCourse(Course course, Student student)
        {
            if(student.StudentName == null)
            {
                throw new ArgumentNullException("Student name null");
            }
            course.CourseStudents.Add(student, null);
            student.StudentLessons = course.CourseLessons;
            return true;
        }

        public bool RemoveStudentFromCourse(Course course, Student student)
        {
            if (course.CourseStudents.Count > 0)
            {
                course.CourseStudents.Remove(student);
            }

            student.StudentLessons = new List<Lesson>();

            return true;
        }
    }
}

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
        void CreateStudent(Student student);
        void DeleteStudent(Student student);
        void AddStudentToCourse(Course course, Student student);
        void RemoveStudentFromCourse(Course course, Student student);
    }

    public class StudentService : IStudentService
    {
        private List<Student> studentData = new List<Student>();

        public void AddStudentToCourse(Course course, Student student)
        {
            course.CourseStudents.Add(student, null);
            student.StudentLessons = course.CourseLessons;
        }

        public void CreateStudent(Student student)
        {
            studentData.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            studentData.Remove(student);
        }

        public void RemoveStudentFromCourse(Course course, Student student)
        {
            course.CourseStudents.Remove(student);
            student.StudentLessons = null;
        }
    }
}

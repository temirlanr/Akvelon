using Xunit;
using OOP.Services;
using OOP.Models;
using System;

namespace OOPTest
{
    public class OOPTest
    {
        [Fact]
        public void AddStudentToCourse_JohnMaths_True()
        {
            IStudentService studentService = new StudentService();

            Student student = new Student();
            student.StudentName = "John";
            Course course = new Course();
            course.CourseName = "Maths";

            bool res = studentService.AddStudentToCourse(course, student);

            Assert.True(res);
        }

        [Fact]
        public void AddStudentToCourse_nullnull_ThrowsArgumentNullException()
        {
            IStudentService studentService = new StudentService();

            Student student = new Student();
            student.StudentName = null;
            Course course = new Course();
            course.CourseName = null;

            Action act = () => studentService.AddStudentToCourse(course, student);

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(act);

            Assert.Equal("error message: ", exception.Message);
        }

        [Fact]
        public void GiveCourseScore_JohnMaths76_True()
        {
            ITeacherService teacherService = new TeacherService();

            Teacher teacher = new Teacher();
            teacher.TeacherName = "Scott";
            Student student = new Student();
            student.StudentName = "John";
            Course course = new Course();
            course.CourseName = "Maths";

            bool res = teacherService.GiveCourseScore(student, course, 76);

            Assert.True(res);
        }
    }
}
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

            Assert.Throws<ArgumentNullException>(act);
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

        [Fact]
        public void CreateLesson_Mathsnull_ThrowsArgumentNullException()
        {
            ILessonService lessonService = new LessonService();

            Course course = new Course();
            course.CourseName = "Maths";
            Lesson lesson = new Lesson();
            lesson.LessonName = null;

            Action act = () => lessonService.CreateLesson(course, lesson);

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void RemoveStudentFromCourse_JohnMaths_True()
        {
            IStudentService studentService = new StudentService();

            Student student = new Student();
            student.StudentName = "John";
            Course course = new Course();
            course.CourseName = "Maths";

            studentService.AddStudentToCourse(course, student);
            bool res = studentService.RemoveStudentFromCourse(course, student);

            Assert.True(res);
        }

        [Fact]
        public void AddCourseToTeacher_ScottStringEmpty_ThrowsArgumentNullException()
        {
            ITeacherService teacherService = new TeacherService();

            Teacher teacher = new Teacher();
            teacher.TeacherName = "Scott";
            Course course = new Course();
            course.CourseName = String.Empty;

            Action act = () => teacherService.AddCourseToTeacher(teacher, course);

            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
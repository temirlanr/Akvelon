using Xunit;
using OOP.Models;
using System;
using OOP;

namespace OOPTest
{
    public class OOPTest
    {
        [Fact]
        public void AddStudentToCourse_StudentCourseEqualCourse()
        {
            Student student = new Student("John");
            Teacher teacher = new Teacher("Kotlin");
            Course course = new Course("Maths", teacher);

            student.AddToCourse(course);

            Assert.Equal(student.StudentCourses[0], course);
        }

        [Fact]
        public void GiveLessonScore_ScoreEqualsCourseStudentScore()
        {
            Teacher teacher = new Teacher("Scott");
            Student student = new Student("John");
            Course course = new Course("Maths", teacher);
            
            student.AddToCourse(course);

            Lesson lesson = new Lesson("Integrals", course);

            teacher.GiveLessonScore(student, lesson, 76);

            Assert.Equal(76, lesson.LessonStudents[student]);
        }

        [Fact]
        public void RemoveStudentFromCourse_StudentCourseIsNull()
        {
            Student student = new("John");
            Teacher teacher = new("Nick");
            Course course = new("Maths", teacher);

            student.AddToCourse(course);
            student.RemoveFromCourse(course);

            Assert.Empty(student.StudentCourses);
        }
    }
}
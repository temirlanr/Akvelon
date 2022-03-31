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
            Student student = new Student();
            student.StudentName = "John";
            Course course = new Course();
            course.CourseName = "Maths";

            TrainingCenter.AddStudentToCourse(course, student);

            Assert.Equal(student.StudentCourses[0], course);
        }

        [Fact]
        public void AddStudentToCourse_NullValues_ThrowsArgumentNullException()
        {
            Student student = new Student();
            student.StudentName = null;
            Course course = new Course();
            course.CourseName = null;

            Action act = () => TrainingCenter.AddStudentToCourse(course, student);

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void GiveCourseScore_ScoreEqualsCourseStudentScore()
        {
            Teacher teacher = new Teacher();
            teacher.TeacherName = "Scott";
            Student student = new Student();
            student.StudentName = "John";
            Course course = new Course();
            course.CourseName = "Maths";

            TrainingCenter.AddCourseToTeacher(teacher, course);
            TrainingCenter.GiveCourseScore(student, course, 76);

            Assert.Equal(76, course.CourseStudents[student]);
        }

        [Fact]
        public void AddLessonToCourse_NullLesson_ThrowsArgumentNullException()
        {
            Course course = new Course();
            course.CourseName = "Maths";
            Lesson lesson = new Lesson();
            lesson.LessonName = null;

            Action act = () => TrainingCenter.AddLessonToCourse(course, lesson);

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void RemoveStudentFromCourse_StudentCourseIsNull()
        {
            Student student = new Student();
            student.StudentName = "John";
            Course course = new Course();
            course.CourseName = "Maths";

            TrainingCenter.AddStudentToCourse(course, student);
            TrainingCenter.RemoveStudentFromCourse(course, student);

            Assert.Empty(student.StudentCourses);
        }

        [Fact]
        public void AddCourseToTeacher_StringEmpty_ThrowsArgumentNullException()
        {
            Teacher teacher = new Teacher();
            teacher.TeacherName = "Scott";
            Course course = new Course();
            course.CourseName = string.Empty;

            Action act = () => TrainingCenter.AddCourseToTeacher(teacher, course);

            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
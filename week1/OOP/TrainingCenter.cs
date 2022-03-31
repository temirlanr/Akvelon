using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class TrainingCenter
    {
        public static void AddStudentToCourse(Course course, Student student)
        {
            if (student.StudentName == null || student.StudentName == string.Empty || student == null)
            {
                throw new ArgumentNullException("Student null");
            }

            if (course.CourseName == null || course.CourseName == string.Empty || course == null)
            {
                throw new ArgumentNullException("Course null");
            }

            course.CourseStudents.Add(student, null);
            student.StudentCourses.Add(course);
            student.StudentLessons = course.CourseLessons;
        }

        public static void RemoveStudentFromCourse(Course course, Student student)
        {
            if (course.CourseStudents.Count > 0)
            {
                course.CourseStudents.Remove(student);
            }

            student.StudentCourses.Remove(course);
            student.StudentLessons = new List<Lesson>();
        }

        public static void AddLessonToCourse(Course course, Lesson lesson)
        {
            if (course.CourseName == null || course.CourseName == string.Empty || course == null)
            {
                throw new ArgumentNullException("Course name null");
            }

            if (lesson.LessonName == null || lesson.LessonName == string.Empty || lesson == null)
            {
                throw new ArgumentNullException("Lesson name null");
            }

            course.CourseLessons.Add(lesson);
            lesson.LessonCourse = course;
        }

        public static void RemoveLessonFromCourse(Course course, Lesson lesson)
        {
            if (course.CourseLessons.Count > 0)
            {
                course.CourseLessons.Remove(lesson);
            }

            lesson.LessonCourse = null;
        }

        public static void AddCourseToTeacher(Teacher teacher, Course course)
        {
            if (teacher.TeacherName == null || teacher.TeacherName == string.Empty || teacher == null)
            {
                throw new ArgumentNullException("Teacher null");
            }

            if (course.CourseName == null || course.CourseName == string.Empty || course == null)
            {
                throw new ArgumentNullException("Course null");
            }

            teacher.TeacherCourses.Add(course);
            course.CourseTeacher = teacher;
        }

        public static void GiveCourseScore(Student student, Course course, int score)
        {
            if (student.StudentName == null || student.StudentName == string.Empty || student == null)
            {
                throw new ArgumentNullException("Student null");
            }

            if (course.CourseName == null || course.CourseName == string.Empty || course == null)
            {
                throw new ArgumentNullException("Course null");
            }

            if (course.CourseTeacher == null)
            {
                throw new ArgumentNullException("Course has no teacher");
            }

            if (score < 0 && score > 100)
            {
                throw new Exception("Score not in range 0-100");
            }

            course.CourseStudents[student] = score;
        }

        public static void GiveLessonScore(Student student, Lesson lesson, int score)
        {
            if (student.StudentName == null || student.StudentName == string.Empty || student == null)
            {
                throw new ArgumentNullException("Student null");
            }

            if (lesson.LessonName == null || lesson.LessonName == string.Empty || lesson == null)
            {
                throw new ArgumentNullException("Lesson null");
            }

            if (lesson.LessonCourse.CourseTeacher == null)
            {
                throw new ArgumentNullException("Course has no teacher");
            }

            if (score < 0 && score > 100)
            {
                throw new Exception("Score not in range 0-100");
            }

            lesson.LessonStudents[student] = score;
        }

        public static void RemoveCourseFromTeacher(Teacher teacher, Course course)
        {
            if (teacher.TeacherCourses.Count > 0)
            {
                teacher.TeacherCourses.Remove(course);
            }

            course.CourseTeacher = null;
        }
    }
}

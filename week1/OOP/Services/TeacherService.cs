using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Services
{
    public interface ITeacherService
    {
        bool AddCourseToTeacher(Teacher teacher, Course course);
        bool RemoveCourseFromTeacher(Teacher teacher, Course course);
        bool GiveCourseScore(Student student, Course course, int score);
        bool GiveLessonScore(Student student, Lesson lesson, int score);
    }

    public class TeacherService : ITeacherService
    {
        public bool AddCourseToTeacher(Teacher teacher, Course course)
        {
            if(teacher.TeacherName == null)
            {
                throw new ArgumentNullException("Teacher name null");
            }
            teacher.TeacherCourses.Add(course);
            course.CourseTeacher = teacher;

            return true;
        }

        public bool GiveCourseScore(Student student, Course course, int score)
        {
            if (score < 0 && score > 100)
            {
                throw new Exception("Score not in range 0-100");
            }

            course.CourseStudents[student] = score;

            return true;
        }

        public bool GiveLessonScore(Student student, Lesson lesson, int score)
        {
            if (score < 0 && score > 100)
            {
                throw new Exception("Score not in range 0-100");
            }

            lesson.LessonStudents[student] = score;

            return true;
        }

        public bool RemoveCourseFromTeacher(Teacher teacher, Course course)
        {
            if (teacher.TeacherCourses.Count > 0)
            {
                teacher.TeacherCourses.Remove(course);
            }

            course.CourseTeacher = null;

            return true;
        }
    }
}

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
        void CreateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
        void AddCourseToTeacher(Teacher teacher, Course course);
        void RemoveCourseFromTeacher(Teacher teacher, Course course);
        void GiveCourseScore(Student student, Course course, int score);
        void GiveLessonScore(Student student, Lesson lesson, int score);
    }

    public class TeacherService : ITeacherService
    {
        private List<Teacher> teacherData = new List<Teacher>();

        public void AddCourseToTeacher(Teacher teacher, Course course)
        {
            teacher.TeacherCourses.Add(course);
            course.CourseTeacher = teacher;
        }

        public void CreateTeacher(Teacher teacher)
        {
            teacherData.Add(teacher);
        }

        public void GiveCourseScore(Student student, Course course, int score)
        {
            course.CourseStudents[student] = score;
        }

        public void GiveLessonScore(Student student, Lesson lesson, int score)
        {
            lesson.LessonStudents[student] = score;
        }

        public void RemoveCourseFromTeacher(Teacher teacher, Course course)
        {
            teacher.TeacherCourses.Remove(course);
            course.CourseTeacher = null;
        }

        public void DeleteTeacher(Teacher teacher)
        {
            teacherData.Remove(teacher);
        }
    }
}

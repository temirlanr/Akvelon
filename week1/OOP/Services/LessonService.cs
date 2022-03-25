using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Services
{
    public interface ILessonService
    {
        bool CreateLesson(Course course, Lesson lesson);
        bool DeleteLesson(Course course, Lesson lesson);
    }

    public class LessonService : ILessonService
    {
        public bool CreateLesson(Course course, Lesson lesson)
        {
            if(course.CourseName == null || course.CourseName == String.Empty || course == null)
            {
                throw new ArgumentNullException("Course name null");
            }

            if(lesson.LessonName == null || lesson.LessonName == String.Empty || lesson == null)
            {
                throw new ArgumentNullException("Lesson name null");
            }

            course.CourseLessons.Add(lesson);
            lesson.LessonCourse = course;

            return true;
        }

        public bool DeleteLesson(Course course, Lesson lesson)
        {
            if (course.CourseLessons.Count > 0)
            {
                course.CourseLessons.Remove(lesson);
            }

            lesson.LessonCourse = null;

            return true;
        }
    }
}

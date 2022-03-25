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
        void CreateLesson(Course course, Lesson lesson);
        void DeleteLesson(Course course, Lesson lesson);
    }

    public class LessonService : ILessonService
    {
        private List<Lesson> lessonData = new List<Lesson>();

        public void CreateLesson(Course course, Lesson lesson)
        {
            lessonData.Add(lesson);
            course.CourseLessons.Add(lesson);
            lesson.LessonCourse = course;
        }

        public void DeleteLesson(Course course, Lesson lesson)
        {
            lessonData.Remove(lesson);
            course.CourseLessons.Remove(lesson);
            lesson.LessonCourse = null;
        }
    }
}

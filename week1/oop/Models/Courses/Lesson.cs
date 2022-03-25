using oop.Models.Person;

namespace oop.Models.Courses
{
    public class Lesson : BaseCourseModel
    {
        public Dictionary<Student, int> LessonStudents;
        public Course LessonCourse;
    }
}
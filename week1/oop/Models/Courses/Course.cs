using oop.Models.Person;

namespace oop.Models.Courses
{
    public class Course : BaseCourseModel
    {
        public Dictionary<Student, int> CourseStudents;
        public List<Lesson> CourseLessons;
        public Teacher CourseTeacher;
    }
}
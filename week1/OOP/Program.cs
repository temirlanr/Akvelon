using OOP.Models;
using OOP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IStudentService studentService = new StudentService();
            ITeacherService teacherService = new TeacherService();
            ILessonService lessonService = new LessonService();

            var students = new List<Student>
            {
                new Student {StudentName = "Craig"},
                new Student {StudentName = "John"},
                new Student {StudentName = null},
                new Student {StudentName = "Katy"},
                new Student {StudentName = "Dana"},
                new Student {StudentName = "Catherine"},
                new Student {StudentName = "Temirlan"},
                new Student {StudentName = "Tyler"},
                new Student {StudentName = "Madylin"},
                new Student {StudentName = "Josh"}
            };

            var teachers = new List<Teacher>
            {
                new Teacher {TeacherName = "Nick"},
                new Teacher {TeacherName = "Jack"},
                new Teacher {TeacherName = "Tina"}
            };

            var courses = new List<Course>
            {
                new Course {CourseName = "Maths"},
                new Course {CourseName = "Geography"},
                new Course {CourseName = "Physics"},
                new Course {CourseName = "Biology"},
                new Course {CourseName = "English"}
            };

            var lessons = new List<Lesson>
            {
                new Lesson {LessonName = "1"},
                new Lesson {LessonName = "2"},
                new Lesson {LessonName = "3"},
                new Lesson {LessonName = "4"},
            };

            studentService.AddStudentToCourse(courses[0], students[0]);
            studentService.AddStudentToCourse(courses[0], students[1]);

            foreach(var student in courses[0].CourseStudents)
            {
                Console.WriteLine(student.Key.StudentName);
            }
        }
    }
}
using OOP.Models;
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

            TrainingCenter.AddStudentToCourse(courses[0], students[0]);
            TrainingCenter.AddStudentToCourse(courses[0], students[1]);
            TrainingCenter.GiveCourseScore(students[0], courses[0], 67);
            TrainingCenter.GiveCourseScore(students[1], courses[0], 80);

            foreach (var student in courses[0].CourseStudents)
            {
                Console.WriteLine(student.Key.StudentName);
                Console.WriteLine(student.Value);
            }
        }
    }
}
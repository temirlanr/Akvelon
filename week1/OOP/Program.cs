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
            var student1 = new Student("Josh");
            var teacher1 = new Teacher("Nick");
            var course1 = new Course("Maths", teacher1);
            var lesson1 = new Lesson("Log", course1);

            student1.AddToCourse(course1);
            Console.WriteLine(lesson1.LessonStudents[student1]);

            teacher1.GiveCourseScore(student1, course1, 80);
            teacher1.GiveLessonScore(student1, lesson1, 76);

            Console.WriteLine(lesson1.LessonStudents[student1]);
            Console.WriteLine(course1.CourseStudents[student1]);
        }
    }
}
using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Services
{
    public interface ICourseService
    {
        void CreateCourse(Course course);
        void DeleteCourse(Course course);
    }

    public class CourseService : ICourseService
    {
        private List<Course> courseData = new List<Course>();

        public void CreateCourse(Course course)
        {
            courseData.Add(course);
        }

        public void DeleteCourse(Course course)
        {
            courseData.Remove(course);
        }
    }
}

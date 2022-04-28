using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseGrade> CourseGrades { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<LessonGrade> LessonGrades { get; set; }
    }
}
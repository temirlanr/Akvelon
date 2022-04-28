using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Data;

namespace TrainingCenter.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        private readonly TCContext context;

        public Teacher(string name, TCContext context)
        {
            Name = name;
            this.context = context;
            AddTeacher();
        }

        private void AddTeacher()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Teachers.Add(this);
            context.SaveChanges();
        }

        private Teacher GetTeacher()
        {
            return context.Teachers.FirstOrDefault(c => c.Id == Id);
        }

        private IEnumerable<Teacher> GetTeachers()
        {
            return context.Teachers.ToList();
        }

        private void DeleteTeacher()
        {
            if (this == null)
            {
                return;
            }

            context.Teachers.Remove(this);
            context.SaveChanges();
        }

        private void UpdateTeacher()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            context.Teachers.Update(this);
            context.SaveChanges();
        }
    }
}
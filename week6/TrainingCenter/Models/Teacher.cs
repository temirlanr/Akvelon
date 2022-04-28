using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Data;

namespace TrainingCenter.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        private readonly TCContext _context;

        public Teacher(TCContext context)
        {
            _context = context;
        }

        public void AddCourse()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            _context.Teachers.Add(this);
            _context.SaveChanges();
        }

        public void DeleteCourse()
        {
            if (this == null)
            {
                return;
            }

            _context.Teachers.Remove(this);
            _context.SaveChanges();
        }

        public void UpdateCourse()
        {
            if (this == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                return;
            }

            _context.Teachers.Update(this);
            _context.SaveChanges();
        }
    }
}
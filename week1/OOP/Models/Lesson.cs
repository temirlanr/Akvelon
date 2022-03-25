﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Models
{
    public class Lesson
    {
        public string LessonName;
        public Dictionary<Student, int?> LessonStudents;
        public Course? LessonCourse;
    }
}

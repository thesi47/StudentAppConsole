using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAppConsole
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Math {  get; set; }
        public double Average { get; set; }
        public double Total { get; set; }
        public string LetterGrade { get; set; } 
        public double CGPA { get; set; }
        public bool IsPassed { get; set; }
    }
}

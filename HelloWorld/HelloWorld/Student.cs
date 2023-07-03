using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Student
    {
        public string Name { get; set; }
        public float Gpa { get; set; }
        public Student(string setName, float setGpa)
        {
            Name = setName;
            Gpa = setGpa;
        }
    }
}

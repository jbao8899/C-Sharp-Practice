using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Trainee : EmployeeForInheritance
    {
        public int WorkingHours { get; set; }
        public int SchoolHours { get; set; }

        public Trainee()
        {
            WorkingHours = 0;
            SchoolHours = 0;
        }

        public Trainee(string setName, int setSalary, int setWorkingHours, int setSchoolHours) : base(setName, setSalary)
        {
            WorkingHours = setWorkingHours;
            SchoolHours = setSchoolHours;
        }

        public void Learn()
        {
            Console.WriteLine($"{Name} just learned for {SchoolHours} hours.");
        }

        public override void Work()
        {
            Console.WriteLine($"The trainee {Name} just worked for {WorkingHours} hours.");
        }

    }
}

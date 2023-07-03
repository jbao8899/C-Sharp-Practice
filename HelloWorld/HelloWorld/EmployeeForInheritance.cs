using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class EmployeeForInheritance
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public EmployeeForInheritance()
        {
            Name = "Unknown";
            Salary = 0;
        }

        public EmployeeForInheritance(string setName, int setSalary)
        {
            Name = setName;
            Salary = setSalary;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Name} just worked.");
        }

        public virtual void Pause()
        {
            Console.WriteLine($"{Name} just took a vacation.");
        }
    }
}

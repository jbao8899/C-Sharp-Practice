using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Boss : EmployeeForInheritance
    {
        public string CompanyCar { get; set; }

        public Boss()
        {
            CompanyCar = "Unknown";
        }

        public Boss(string setName, int setSalary, string setCompanyCar) : base(setName, setSalary)
        {
            CompanyCar = setCompanyCar;
        }

        public void Lead()
        {
            Console.WriteLine($"{Name} just led.");
        }
    }
}

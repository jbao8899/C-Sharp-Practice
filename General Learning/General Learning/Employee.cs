using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Employee
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Rate { get; set; }

        public float Salary
        {
            get
            {
                return Rate * 8.0f * 5.0f * 4.0f * 12.0f;
            }
        }

        public Employee(string setRole, string setName, int setAge, float setRate)
        {
            Role = setRole;
            Name = setName;
            Age = setAge;
            Rate = setRate;
        }
    }
}

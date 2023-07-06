using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class DogForEnumerating
    {
        public string Name { get; set; }
        public bool IsNaughtyDog { get; set; }

        public DogForEnumerating(string setName, bool setIsNaughtyDog)
        {
            Name = setName;
            IsNaughtyDog = setIsNaughtyDog;
        }

        public void GiveTreat(int numTreats)
        {
            Console.WriteLine("The dog {0} got {1} treats!", Name, numTreats);
        }
    }
}

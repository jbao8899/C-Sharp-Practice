using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsHungry { get; set; }

        public Animal(string setName, int setAge)
        {
            Name = setName;
            Age = setAge;
            IsHungry = true;
        }

        public virtual void MakeSound()
        {
            // Empty function body, shoud be overriden by child classes
        }

        public virtual void Eat()
        {
            // Use this function body if the child class does not override this
            if (IsHungry)
            {
                Console.WriteLine("{0} eats.", Name);
                IsHungry = false;
            }
            else
            {
                Console.WriteLine("{0} is not hungry.", Name);
            }
        }

        public virtual void Play()
        {
            // Can, but does not have to be, overridden by child classe
            Console.WriteLine("{0} plays.", Name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Dog : Animal
    {
        public bool IsHappy { get; set; }
        public Dog(string setName, int setAge) : base(setName, setAge)
        {
            IsHappy = true;
        }

        public override void Eat()
        {
            base.Eat(); // Dog eats just like other animals
        }

        public override void MakeSound()
        {
            //base.MakeSound(); // This is not needed

            // Makes a different sound
            Console.WriteLine("Woof!");
        }

        public override void Play()
        {
            if (IsHappy)
            {
                base.Play();
            }
            else
            {
                Console.WriteLine("The dog is unhappy and does not want to play.");
            }

        }
    }
}

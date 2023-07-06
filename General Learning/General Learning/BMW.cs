using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    // Can also seal whole class to prevent any child classes
    // sealed class BMW : Car137
    
    // A BMW is a Car137
    class BMW : Car137
    {
        public string Model { get; set; }
        private string Brand { get; set; }

        public BMW(int setHorsepower, string setColor, string setModel) : base(setHorsepower, setColor)
        {
            Model = setModel;
            Brand = "BMW";
        }

        public new void ShowDetails()
        {
            Console.WriteLine($"This {Brand} {Model} is {Color} and has {Horsepower} horsepower.");
        }

        public sealed override void Repair() // cannot have sealed virtual method
        {
            Console.WriteLine($"{Brand} {Model} was repaired!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    class Audi : Car137
    {
        public string Model { get; set; }
        private string Brand { get; set; }

        // Can use base() to set private fields held by parents
        public Audi(int setHorsepower, string setColor, string setModel) : base(setHorsepower, setColor)
        {
            Model = setModel;
            Brand = "Audi";
        }
        
        public new void ShowDetails()
        {
            Console.WriteLine($"This {Brand} {Model} is {Color} and has {Horsepower} horsepower.");
        }
        
        public override void Repair()
        {
            Console.WriteLine($"{Brand} {Model} was repaired!");
        }
    }

}

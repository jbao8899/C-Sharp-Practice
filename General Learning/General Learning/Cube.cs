using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Cube : Shape3D
    {
        public double SideLength { get; set; }

        public Cube(double setSideLength)
        {
            Name = "Cube";
            SideLength = setSideLength;
        }

        public override void GetInfo()
        {
            base.GetInfo(); // First print the same message as before
            // Then add more info
            Console.WriteLine("Its side length is {0}", SideLength); 
        }

        public override double Volume()
        {
            return Math.Pow(SideLength, 3);
        }
    }
}

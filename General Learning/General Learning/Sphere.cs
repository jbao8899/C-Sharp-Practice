using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Sphere : Shape3D
    {
        public double Radius { get; set; }

        public Sphere(double setRadius)
        {
            Name = "Sphere";
            Radius = setRadius;
        }

        public override void GetInfo()
        {
            base.GetInfo(); // First print the same message as before
            // Then add more info
            Console.WriteLine("Its radius is {0}", Radius);
        }

        public override double Volume()
        {
            return (4 / 3) * Math.PI * Math.Pow(Radius, 3);
        }
    }
}

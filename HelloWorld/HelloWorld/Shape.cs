using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    abstract class Shape3D // The abstract keyword prevents instantiation
    {
        public string Name { get; set; }

        // Child classes can override this.
        public virtual void GetInfo()
        {
            Console.WriteLine($"This is a {Name}");
        }

        // Any child class must implement this method
        public abstract double Volume();
    }
}

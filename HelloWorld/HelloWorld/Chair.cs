using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Chair : Furniture, IDestroyable
    {
        public string DestructionSound { get; set; }

        public void Destroy()
        {
            Console.WriteLine($"A {Color} chair was destroyed.");
            Console.WriteLine("Play sound {0}", DestructionSound);
            Console.WriteLine("Spawning chair parts");
        }

        public Chair(string setColor, string setMaterial) : base(setColor, setMaterial)
        {
            DestructionSound = "chair_destruction_sound.mp4";
        }
    }
}

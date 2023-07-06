using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Car : Vehicle, IDestroyable
    {
        public string DestructionSound { get; set; }

        // Will be destroyed if car is destroyed.
        public List<IDestroyable> DestroyablesNearby { get; set; } 

        public void Destroy()
        {
            Console.WriteLine("Play sound {0}", DestructionSound);
            Console.WriteLine("Create fire.");
            
            // Destroy each nearby destroyable object
            foreach (IDestroyable destroyable in DestroyablesNearby)
            {
                destroyable.Destroy();
            }
        }

        public Car(float setSpeed, string setColor) : base(setSpeed, setColor)
        {
            DestructionSound = "car_destruction_sound.mp4";
            DestroyablesNearby = new List<IDestroyable>();
        }
    }
}

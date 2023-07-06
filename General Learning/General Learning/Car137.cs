using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    class Car137
    {
        public int Horsepower { get; set; }
        public string Color { get; set; }

        // Each Car137 HAS A carIDInfo 
        protected CarIDInfo carIDInfo = new CarIDInfo(); 

        public void SetCarIDInfo(int setVIN, string setOwner)
        {
            carIDInfo.VIN = setVIN;
            carIDInfo.owner = setOwner;
        }

        public void GetCarIDInfo()
        {
            Console.WriteLine($"The car has a VIN of {carIDInfo.VIN} and is owned by {carIDInfo.owner}.");
        }

        public Car137(int setHorsepower, string setColor)
        {
            Horsepower = setHorsepower;
            Color = setColor;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"This car is {Color} and has {Horsepower} horsepower.");
        }

        public virtual void Repair()
        {
            Console.WriteLine("Car was repaired!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    //Child class
    internal class Tv : MediaDevice
    {
        public Tv(bool setIsOn, string setBrand) : base(setIsOn, setBrand)
        {
        }

        public void WatchTv()
        {
            if (IsOn)
            {
                Console.WriteLine("Watching the TV");
            }
            else
            {
                Console.WriteLine("The TV is switched off. Turn it on to watch.");
            }
        }

    }
}

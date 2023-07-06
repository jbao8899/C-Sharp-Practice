using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    //Child class
    public class Radio : MediaDevice // In same namespace, so you don't need to specify that
    {
        public Radio(bool setIsOn, string setBrand) : base(setIsOn, setBrand)         {
            // If Radio had some of its own Properties not shared with MediaDevice, they would be initialized here
        }

        public void ListenRadio()
        {
            if (IsOn)
            {
                Console.WriteLine("Listening to the radio");
            }
            else
            {
                Console.WriteLine("The radio is switched off. Turn it on to listen.");
            }
        }
    }
}

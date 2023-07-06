using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    // Base/Parent class
    internal class MediaDevice
    {
        public bool IsOn { get; set; }

        public string Brand { get; set; }

        public MediaDevice(bool setIsOn, string setBrand)
        {
            IsOn = setIsOn;
            Brand = setBrand;
        }

        public void SwitchOn()
        {
            IsOn = true;
        }

        public void SwitchOff()
        {
            IsOn = false;
        }
    }
}

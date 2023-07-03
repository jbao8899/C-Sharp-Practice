using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    interface IDestroyable
    {
        public string DestructionSound { get; set; }

        // Method to destroy an object
        public void Destroy();
    }
}

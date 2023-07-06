using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class Furniture
    {
        public string Color { get; set; }
        public string Material { get; set; }

        public Furniture()
        {
            Color = "Unknown Color";
            Material = "Unknown Material";
        }

        public Furniture(string setColor, string setMaterial)
        {
            Color = setColor;
            Material = setMaterial;
        }
    }
}

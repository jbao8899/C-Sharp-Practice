﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Vehicle
    {
        public float Speed { get; set; }
        public string Color { get; set; }

        public Vehicle()
        {
            Speed = -1;
            Color = "Unknown Color";
        }

        public Vehicle(float setSpeed, string setColor)
        {
            Speed = setSpeed;
            Color = setColor;
        }
    }
}

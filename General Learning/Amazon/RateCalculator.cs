﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    public class RateCalculator
    {
        public int Calculate(Customer customer)
        {
            Random random = new Random();
            return random.Next(0, 100);
        }
    }
}

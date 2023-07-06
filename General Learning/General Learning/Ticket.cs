using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Ticket : IEquatable<Ticket> // We can compare two tickets 
    {
        public int DurationInHours { get; set; }

        public Ticket(int setDurationInHours)
        {
            DurationInHours = setDurationInHours;
        }

        public bool Equals(Ticket other)
        {
            return DurationInHours == other.DurationInHours;
        }
    }
}

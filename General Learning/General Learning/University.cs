using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    class University
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public University(int setID, string setName)
        {
            ID = setID;
            Name = setName;
        }

        public void Print()
        {
            Console.WriteLine("University {0} with ID {1}", Name, ID);
        }
    }
}

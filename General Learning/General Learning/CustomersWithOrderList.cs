using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class CustomersWithOrderList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; } // could maybe initialize a list in the field directly

        public CustomersWithOrderList() {
            ID = -1;
            Name = "";
            Orders = new List<Order>(); // Need to initialize any lists and such
        }

        public CustomersWithOrderList(int setID, string setName)
            : this() // to create the list of Orders
        {
            ID = setID;
            Name = setName;
        }
    }
}

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
        public List<Order> orders { get; set; }
    }
}

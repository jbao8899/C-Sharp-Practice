using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class OldOrder
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public OldOrder(int setOrderId, int setQuantity)
        {
            OrderId = setOrderId;
            Quantity = setQuantity;
        }

        public void ProcessOrder()
        {
            Console.WriteLine("Order {0} processed!", OrderId);
        }

    }
}

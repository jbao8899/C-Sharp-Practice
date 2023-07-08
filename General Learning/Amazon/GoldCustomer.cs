using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    public class GoldCustomer : Customer
    {
        public void OfferVoucher()
        {
            int rating = _rateCalculator.Calculate(this);
            if (rating > 50)
            {
                Console.WriteLine("Voucher offered to {0}", Name);
            }
        }
    }
}

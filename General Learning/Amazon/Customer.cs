using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected readonly RateCalculator _rateCalculator;

        public Customer()
        {
            _rateCalculator = new RateCalculator();
        }

        public void Promote()
        {
            if (_rateCalculator.Calculate(this) > 50)
            {
                Console.WriteLine("Customer promoted");
            }
        }
    }
}

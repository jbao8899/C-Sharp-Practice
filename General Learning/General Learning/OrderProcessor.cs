using System;

namespace General_Learning
{
    public class OrderProcessor
    {
        // Using IShippingCalculator instead of ShippingCalculator
        // avoids tight coupling, allows isolating this class during unit testing
        // (we can use a fake shipping calculator class so that testing this clas
        // does not rely on the actual shipping calculator class)
        // this is loose coupling
        // 
        private readonly IShippingCalculator _shippingCalculator;

        public OrderProcessor(IShippingCalculator shippingCalculator)
        {
            _shippingCalculator = shippingCalculator;
        }

        public void Process(Order order)
        {
            if (order.IsShipped)
            {
                throw new InvalidOperationException("This order is already processed.");
            }

            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate = DateTime.Today.AddDays(1)
            };
        }
    }
}
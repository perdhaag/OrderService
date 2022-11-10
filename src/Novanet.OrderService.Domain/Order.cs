﻿namespace Novanet.OrderService.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        
        public int OrderType { get; private set; }
        public Customer Customer { get; private set; }

        public decimal Total { get; private set; }

        public IList<OrderLine> OrderLines { get; private set; }

        public void NewGuid()
        {
            Id = Guid.NewGuid();
        }
        
        public void UpdateFreightCost(Order order, int freightProductId)
        {
            var weight = order.OrderLines.Sum(o => o.Quantity * o.WeightTotal);

            var freightCost = Domain.Helpers.FreightCalculator.Calculate(order.Customer.Zip, weight);

            var freight = order.OrderLines.FirstOrDefault(o => o.ProductId == freightProductId);

            if (freight == null)
            {
                order.OrderLines.Add(new Domain.OrderLine(
                    productId: freightProductId,
                    productName: "Frakt",
                    cost: freightCost, 
                    quantity: 1));
            }
            else
            {
                freight.Cost = freightCost;
            }            
        }
        public void SetOrderCustomer(Customer customer)
        {
            Customer = customer;
        }

        public void UpdateOrderTotal(decimal newOrderTotal)
        {
            Total = newOrderTotal;
        }
    }
}
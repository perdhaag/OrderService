using Novanet.OrderService.Domain.Helpers;

namespace Novanet.OrderService.Domain;

public class Order
{
    public OrderId Id { get; private set; }

    public OrderType OrderType { get; private set; }
    public Customer Customer { get; private set; }

    public decimal Total { get; private set; }

    public IList<OrderLine> OrderLines { get; private set; }

    public void NewGuid()
    {
        Id = OrderId.NewId();
    }

    public void UpdateFreightCost(Order order, int freightProductId)
    {
        var weight = order.OrderLines.Sum(o => o.Quantity * o.WeightTotal);

        var freightCost = FreightCalculator.Calculate(order.Customer.Zip, weight);

        var freight = order.OrderLines.FirstOrDefault(o => o.ProductId == freightProductId);

        if (freight == null)
            order.OrderLines.Add(new OrderLine(
                freightProductId,
                "Frakt",
                freightCost,
                1));
        else
            freight.SetProductCost(freightCost);
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
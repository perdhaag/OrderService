using Novanet.OrderService.Domain.Helpers;
using Novanet.OrderService.Domain.Mementos;

namespace Novanet.OrderService.Domain;

public class Order : AggregateRoot, IHaveState<OrderMemento>
{

    private readonly List<OrderLine> _orderLines;
    public OrderId Id { get; private set; } = null!;

    public OrderType? OrderType { get; private set; }
    
    public Customer Customer { get; private set; }

    public decimal Total { get; private set; }

    public IReadOnlyList<OrderLine> OrderLines
    {
        get => _orderLines;
    }

    public OrderMemento State => new()
    {
        Id = Id,
        OrderType = OrderType,
        CustomerId = Customer.Id,
        Total = Total,
        OrderLines = _orderLines.Select(x => x.State).ToList()
    };
    public void NewGuid()
    {
        Id = OrderId.NewId();
    }
    public void RemoveOrderLine(OrderLine line)
    {
        _orderLines.Remove(line);
    }
    public void AddOrderLine(OrderLine line)
    {
        _orderLines.Add(line);
    }
    public void UpdateFreightCost(Order order, int freightProductId)
    {
        var weight = order.OrderLines.Sum(o => o.Quantity * o.WeightTotal);

        var freightCost = FreightCalculator.Calculate(order.Customer.Zip, weight);

        var freight = order.OrderLines.FirstOrDefault(o => o.ProductId == freightProductId);

        if (freight == null)
            order._orderLines.Add(new OrderLine(
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

    public Order FromMemento(OrderMemento memento) => new Order
    {
        Id = memento.Id.To<OrderId>(),
        Total = memento.Total,
        Customer = Customer,
        OrderType = memento.OrderType.To<OrderType>(),
    };
}
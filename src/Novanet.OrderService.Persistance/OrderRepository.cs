using Novanet.OrderService.Domain;
using Novanet.OrderService.Domain.Interfaces;
using Novanet.OrderService.Infrastructure;
using static System.Guid;

namespace Novanet.OrderService.Persistance;

public class OrderRepository : IOrderRepository
{

    private readonly OrderContext _orderContext;
    private readonly IList<Order> _orders = new List<Order>();

    public OrderRepository(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public Order Save(Order order)
    {
        if (order.Id == Empty)
            order.NewGuid();

        _orderContext.Orders.Add(order.State);

        return order;
    }

    public Order? Get(Guid orderId)
    {
        var a = _orderContext.Orders.FirstOrDefault(o => o.Id == orderId);
        return new Order().FromMemento(a);
    }

    public IList<Order> FetchAll()
    {
        return _orderContext.Orders.Select(o => new Order().FromMemento(o)).ToList();
    }
}
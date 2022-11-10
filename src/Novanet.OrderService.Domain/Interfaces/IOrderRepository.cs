namespace Novanet.OrderService.Domain.Interfaces;

public interface IOrderRepository
{
    Order Save(Order order);
    Order? Get(Guid orderId);
    IList<Order> FetchAll();
}
using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Application.Queries.Order.Query;

public class OrderQueries
{

    private readonly IOrderRepository _orderRepository;
    public OrderQueries(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Domain.Order? Get(Guid orderId)
    {
        return _orderRepository.Get(orderId);
    }

    public IEnumerable<Domain.Order> FetchAll()
    {
        return _orderRepository.FetchAll();
    }
}
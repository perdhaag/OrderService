using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Application.Features;

public class RemoveOrderLine
{
    public record Command(Guid OrderId, Guid OrderLineId);
    private readonly IOrderRepository _orderRepository;
    private const int FreightProductId = 99;

    public RemoveOrderLine(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Domain.Order Handle(Command command)
    {
        var order = _orderRepository.Get(command.OrderId);

        if (order == null)
            throw new ArgumentException("Invalid orderId");

        var line = order.OrderLines.FirstOrDefault(o => o.Id == command.OrderLineId);

        if (line == null)
            throw new ArgumentException("Invalid orderLineId");

        order.RemoveOrderLine(line);
        
        order.UpdateFreightCost(order, FreightProductId);

        order.UpdateOrderTotal(order.OrderLines.Sum(l => l.Cost * l.Quantity));

        return _orderRepository.Save(order);
    }


}
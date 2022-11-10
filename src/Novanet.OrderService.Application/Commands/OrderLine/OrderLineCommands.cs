using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Application.Commands.OrderLine;

public class OrderLineCommands
{
    private const int FreightProductId = 99;

    private readonly IOrderRepository _orderRepository;

    public OrderLineCommands(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Domain.Order AddLine(Guid orderId, Domain.OrderLine line)
    {
        var order = _orderRepository.Get(orderId);

        if (order == null)
            throw new ArgumentException("Invalid orderId");

        line.SetProductTotalWeight(line.Quantity * line.WeightPerUnit);

        order.OrderLines.Add(line);

        order.UpdateFreightCost(order, FreightProductId);

        order.UpdateOrderTotal(order.OrderLines.Sum(l => l.Cost * l.Quantity));

        return _orderRepository.Save(order);
    }

    public Domain.Order RemoveLine(Guid orderId, Guid orderLineId)
    {
        var order = _orderRepository.Get(orderId);

        if (order == null)
            throw new ArgumentException("Invalid orderId");

        var line = order.OrderLines.FirstOrDefault(o => o.Id == orderLineId);

        if (line == null)
            throw new ArgumentException("Invalid orderLineId");

        order.OrderLines.Remove(line);

        order.UpdateFreightCost(order, FreightProductId);

        order.UpdateOrderTotal(order.OrderLines.Sum(l => l.Cost * l.Quantity));

        return _orderRepository.Save(order);
    }
}
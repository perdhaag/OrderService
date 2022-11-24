using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Application.Features;

public class AddOrderLine
{
    
    public record Command(Guid OrderId, Domain.OrderLine Line);

    private readonly IOrderRepository _orderRepository;
    private const int FreightProductId = 99;

    public AddOrderLine(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Domain.Order Handle(Command command)
    {
        var order = _orderRepository.Get(command.OrderId);

        if (order == null)
            throw new ArgumentException("Invalid orderId");

        command.Line.SetProductTotalWeight(command.Line.Quantity * command.Line.WeightPerUnit);

        order.OrderLines.Add(command.Line);

        order.UpdateFreightCost(order, FreightProductId);

        order.UpdateOrderTotal(order.OrderLines.Sum(l => l.Cost * l.Quantity));

        return _orderRepository.Save(order);
    }
}
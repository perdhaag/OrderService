using Microsoft.AspNetCore.Mvc;
using Novanet.OrderService.Application.Commands.OrderLine;

namespace Novanet.OrderService.Controllers.OrderLine;

[ApiController]
[Route("[Controller]")]
public class OrderLineController
{
    private readonly OrderLineCommands _orderLineCommands;
    
    public OrderLineController(OrderLineCommands orderLineCommands)
    {
        _orderLineCommands = orderLineCommands;
    }
    
    /// <summary>
    /// Add order line
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="line"></param>
    /// <returns></returns>
    [HttpPost("{orderId}/lines", Name = "AddOrderLine")]
    public Domain.Order AddLine(Guid orderId, Domain.OrderLine line)
    {
        return _orderLineCommands.AddLine(orderId, line);
    }

    /// <summary>
    /// Delete order line
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="orderLineId"></param>
    /// <returns></returns>
    [HttpDelete("{orderId}/lines/{orderLineId}", Name = "RemoveOrderLine")]
    public Domain.Order RemoveLine(Guid orderId, Guid orderLineId)
    {
        return _orderLineCommands.RemoveLine(orderId, orderLineId);
    }
}
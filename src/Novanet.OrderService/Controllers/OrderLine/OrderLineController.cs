using Microsoft.AspNetCore.Mvc;
using Novanet.OrderService.Application.Features;

namespace Novanet.OrderService.Controllers.OrderLine;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[Controller]")]
public class OrderLineController
{
    private readonly AddOrderLine _addOrderLine;
    private readonly RemoveOrderLine _removeOrderLine;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="addOrderLine"></param>
    /// <param name="removeOrderLine"></param>
    public OrderLineController(AddOrderLine addOrderLine, RemoveOrderLine removeOrderLine)
    {
        _addOrderLine = addOrderLine;
        _removeOrderLine = removeOrderLine;
    }

    /// <summary>
    ///     Add order line
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="line"></param>
    /// <returns></returns>
    [HttpPost("{orderId}/lines", Name = "AddOrderLine")]
    public Domain.Order AddLine(Guid orderId, Domain.OrderLine line)
    {
        return _addOrderLine.Handle(new AddOrderLine.Command(orderId, line));
    }

    /// <summary>
    ///     Delete order line
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="orderLineId"></param>
    /// <returns></returns>
    [HttpDelete("{orderId}/lines/{orderLineId}", Name = "RemoveOrderLine")]
    public Domain.Order RemoveLine(Guid orderId, Guid orderLineId)
    {
        return _removeOrderLine.Handle(new RemoveOrderLine.Command(orderId, orderLineId));
    }
}
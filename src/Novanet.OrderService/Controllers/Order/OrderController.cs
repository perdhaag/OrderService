using Microsoft.AspNetCore.Mvc;
using Novanet.OrderService.Application.Commands.Order;
using Novanet.OrderService.Application.Queries.Order.Query;

namespace Novanet.OrderService.Controllers.Order;


[ApiController]
[Route("[controller]")] 
public class OrderController : ControllerBase
{
    private readonly OrderQueries _orderQueries;
    private readonly OrderCommands _orderCommands;
    
    public OrderController(OrderQueries orderQueries, OrderCommands orderCommands)
    {
        _orderQueries = orderQueries;
        _orderCommands = orderCommands;
    }
    
    /// <summary>
    /// Get order
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpGet("{orderId}", Name = "GetOrders")]
    public Domain.Order? Get(Guid orderId)
    {
        return _orderQueries.Get(orderId);
    }

    /// <summary>
    /// Fetch all orders
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "Fetch")]
    public IEnumerable<Domain.Order> Fetch()
    {
        return _orderQueries.FetchAll();
    }

    /// <summary>
    /// Create new order
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateOrder")]
    public async Task<Domain.Order> Create(Guid customerId)
    {
        return await _orderCommands.Create(customerId);
    }
}
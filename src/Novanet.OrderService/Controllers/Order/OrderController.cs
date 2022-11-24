using Microsoft.AspNetCore.Mvc;
using Novanet.OrderService.Application.Features;
using Novanet.OrderService.Application.Queries.Order.Query;

namespace Novanet.OrderService.Controllers.Order;

/// <inheritdoc />
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly CreateOrder _createOrder;
    private readonly OrderQueries _orderQueries;

    /// <inheritdoc />
    public OrderController(OrderQueries orderQueries, CreateOrder createOrder)
    {
        _orderQueries = orderQueries;
        _createOrder = createOrder;
    }

    /// <summary>
    ///     Get order
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpGet("{orderId}", Name = "GetOrders")]
    public Domain.Order? Get(Guid orderId)
    {
        return _orderQueries.Get(orderId);
    }

    /// <summary>
    ///     Fetch all orders
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "Fetch")]
    public IEnumerable<Domain.Order> Fetch()
    {
        return _orderQueries.FetchAll();
    }

    /// <summary>
    ///     Create new order
    /// </summary>
    /// <returns></returns>
    [HttpPost(Name = "CreateOrder")]
    public async Task<Domain.Order> Create(Guid customerId)
    {
        return await _createOrder.Handle(new CreateOrder.Command(customerId));
    }
}
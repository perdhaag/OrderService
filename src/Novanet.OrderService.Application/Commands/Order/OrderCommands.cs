using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Application.Commands.Order;

public class OrderCommands
{
    private readonly ICustomerClient _customerClient;
    private readonly IOrderRepository _orderRepository;

    public OrderCommands(IOrderRepository orderRepository, ICustomerClient customerClient)
    {
        _orderRepository = orderRepository;
        _customerClient = customerClient;
    }

    public async Task<Domain.Order> Create(Guid customerId)
    {
        var order = new Domain.Order();

        var customer = await _customerClient.Get(customerId);
        order.SetOrderCustomer(customer);

        return _orderRepository.Save(order);
    }
}
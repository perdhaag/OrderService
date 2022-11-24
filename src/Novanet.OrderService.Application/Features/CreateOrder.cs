using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Application.Features;

public class CreateOrder
{
    public record Command(Guid CustomerId);
    
    private readonly ICustomerClient _customerClient;
    private readonly IOrderRepository _orderRepository;

    public CreateOrder(ICustomerClient customerClient, IOrderRepository orderRepository)
    {
        _customerClient = customerClient;
        _orderRepository = orderRepository;
    }

    public async Task<Domain.Order> Handle(Command command)
    {
        var order = new Domain.Order();

        var customer = await _customerClient.Get(command.CustomerId);
        order.SetOrderCustomer(customer);

        return _orderRepository.Save(order);
    }
}
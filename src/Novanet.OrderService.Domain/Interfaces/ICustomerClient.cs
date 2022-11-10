namespace Novanet.OrderService.Domain.Interfaces;

public interface ICustomerClient
{
    Task<Customer> Get(Guid id);
}
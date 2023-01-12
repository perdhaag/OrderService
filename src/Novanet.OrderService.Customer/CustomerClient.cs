using Novanet.OrderService.Domain;
using Novanet.OrderService.Domain.Interfaces;
using Novanet.OrderService.Infrastructure;

namespace Novanet.OrderService.Customer;

public class CustomerClient : ICustomerClient
{
    private readonly OrderContext _storeContext;

    public CustomerClient(OrderContext storeContext)
    {
        _storeContext = storeContext;
    }

    public async Task<Domain.Customer> Get(Guid customerId)
    {
        var customer = _storeContext.Customers.FirstOrDefault(x => x.Id == customerId);
        return new Domain.Customer(
            customer.Id.To<CustomerId>(),
            customer.Name.To<CustomerName>(),
            customer.Address.To<CustomerAddress>(),
            customer.Zip.To<CustomerZip>(),
            customer.City.To<CustomerCity>());
    }
}
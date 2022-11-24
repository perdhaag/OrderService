using System.Net.Http.Json;
using Novanet.OrderService.Domain;
using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Customer;

public class CustomerClient : ICustomerClient
{
    private readonly HttpClient _client;

    public CustomerClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<Domain.Customer> Get(Guid customerId)
    {
        var response = await _client.GetFromJsonAsync<CustomerDto>($"{_client.BaseAddress}customer?customerId={customerId}");

        return new Domain.Customer(
            response?.Id.To<CustomerId>(),
            response?.Name.To<CustomerName>()!,
            response!.Adr1.To<CustomerAddress>(), 
            response.Zip.To<CustomerZip>(), 
            response.City.To<CustomerCity>());
    }
}
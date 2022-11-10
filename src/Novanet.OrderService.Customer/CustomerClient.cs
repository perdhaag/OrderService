using System.Net.Http.Json;
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

        return new Domain.Customer(response.Id, response.Name, response.Adr1, response.Zip, response.City);
    }
}
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
        var response = await _client.GetAsync($"{_client.BaseAddress}customer?customerId={customerId}");

        var dto = await response.Content.ReadAsAsync<CustomerDto>();
        return new Domain.Customer(dto.Id, dto.Name, dto.Adr1, dto.Zip, dto.City);
    }
}
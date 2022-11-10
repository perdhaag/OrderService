using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Customer;

public class CustomerClient : ICustomerClient
{
    public async Task<Domain.Customer> Get(Guid customerId)
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync($"http://api.novanet.no/customer?customerId={customerId}");

            var dto = await response.Content.ReadAsAsync<CustomerDto>();

            return new Domain.Customer(dto.Id, dto.Name, dto.Adr1, dto.Zip, dto.City);
        }
    }
}


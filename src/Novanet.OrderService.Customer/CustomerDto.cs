namespace Novanet.OrderService.Customer;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Adr1 { get; set; }
    public int Zip { get; set; }
    public string City { get; set; }
}
namespace Novanet.OrderService.Customer;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Adr1 { get; set; } = null!;
    public int Zip { get; set; }
    public string City { get; set; } = null!;
}
namespace Novanet.OrderService.Domain;

public class Product : AggregateRoot
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Weight { get; private set; }
}
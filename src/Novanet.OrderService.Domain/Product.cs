namespace Novanet.OrderService.Domain;

public class Product : AggregateRoot
{
    public int? Id { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public decimal? Price { get; private set; } = null!;
    public decimal? Weight { get; private set; } = null!;
}
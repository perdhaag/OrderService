namespace Novanet.OrderService.Domain.Mementos;

public sealed class OrderLineMemento
{
    public Guid Id { get; set; }
    public int ProductId { get; set;  }
    public string? ProductName { get; set; }
    public decimal Quantity { get; set; }
    public decimal WeightPerUnit { get; set; }
    public decimal WeightTotal { get; set; }
    public decimal Cost { get;  set; }
}
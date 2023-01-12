namespace Novanet.OrderService.Domain.Mementos;

public sealed class OrderMemento
{
    public Guid Id { get; set; }

    public string OrderType { get; set; }

    public decimal Total { get; set; }

    public Guid CustomerId { get; set; }
    
    public ICollection<OrderLineMemento> OrderLines { get;  set; }
}
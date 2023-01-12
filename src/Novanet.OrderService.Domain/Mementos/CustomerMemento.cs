namespace Novanet.OrderService.Domain.Mementos;

public sealed class CustomerMemento
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public string Zip { get; set; }
    
    public string City { get; set; }
}
namespace Novanet.OrderService.Domain;

public class Customer : AggregateRoot
{
    public Customer(CustomerId id, CustomerName name, CustomerAddress address, CustomerZip zip, CustomerCity city)
    {
        Id = id;
        Name = name;
        Address = address;
        Zip = zip;
        City = city;
    }

    public CustomerId Id { get; }
    public CustomerName Name { get; }
    public CustomerAddress Address { get; }
    public CustomerZip Zip { get; }
    public CustomerCity City { get; }
}
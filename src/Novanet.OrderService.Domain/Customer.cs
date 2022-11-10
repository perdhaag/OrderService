namespace Novanet.OrderService.Domain;

public class Customer
{
    public Customer(Guid id, string name, string address, int zip, string city)
    {
        Id = id;
        Name = name;
        Address = address;
        Zip = zip;
        City = city;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Address { get; }
    public int Zip { get; }
    public string City { get; }
}
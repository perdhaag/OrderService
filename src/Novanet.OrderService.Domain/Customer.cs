namespace Novanet.OrderService.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }

        public Customer(Guid id, string name, string address, int zip, string city)
        {
            Id = id;
            Name = name;
            Address = address;
            Zip = zip;
            City = city;
        }
    }
}

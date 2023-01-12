using Novanet.OrderService.Domain.Mementos;

namespace Novanet.OrderService.Domain;

public partial class Customer : IHaveState<CustomerMemento>
{
    public CustomerMemento State => new CustomerMemento
    {
        Id = Id,
        Address = Address,
        City = City,
        Name = Name,
        Zip = Zip
    };

    public static Customer FromMemento(CustomerMemento memento) => new(
        memento.Id.To<CustomerId>(),
        memento.Name.To<CustomerName>(),
        memento.Address.To<CustomerAddress>(),
        memento.Zip.To<CustomerZip>(),
        memento.City.To<CustomerCity>()
    );
}
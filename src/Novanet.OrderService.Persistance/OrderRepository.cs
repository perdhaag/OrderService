using Novanet.OrderService.Domain;
using Novanet.OrderService.Domain.Interfaces;

namespace Novanet.OrderService.Persistance
{

    public class OrderRepository : IOrderRepository
    {
        private IList<Order> _orders = new List<Order>();

        public Order Save(Order order)
        {
            if(order.Id == new Guid())
                order.NewGuid();

            _orders.Add(order);

            return order;
        }

        public Order? Get(Guid orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
        }

        public IList<Order> FetchAll()
        {
            return _orders;
        }
    }
}

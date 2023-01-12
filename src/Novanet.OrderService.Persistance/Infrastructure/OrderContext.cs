using Microsoft.EntityFrameworkCore;
using Novanet.OrderService.Domain;
using Novanet.OrderService.Domain.Mementos;

namespace Novanet.OrderService.Infrastructure;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
        
    }
    public DbSet<OrderMemento> Orders { get; set; }
    
    public DbSet<CustomerMemento> Customers { get; set; }
}
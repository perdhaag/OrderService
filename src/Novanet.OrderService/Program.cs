using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Novanet.OrderService.Application.Features;
using Novanet.OrderService.Application.Queries.Order.Query;
using Novanet.OrderService.Customer;
using Novanet.OrderService.Domain.Interfaces;
using Novanet.OrderService.Domain.Mementos;
using Novanet.OrderService.Infrastructure;
using Novanet.OrderService.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OrderContext>(options =>
{
    options.UseInMemoryDatabase("InMem");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//Bør vel ha et interface her med en customer implementasjon. 
builder.Services.AddTransient<ICustomerClient, CustomerClient>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<OrderQueries>();
builder.Services.AddScoped<RemoveOrderLine>();
builder.Services.AddScoped<AddOrderLine>();
builder.Services.AddScoped<CreateOrder>();

// builder.Services.AddHttpClient<ICustomerClient>(options =>
// {
//     options.BaseAddress = new Uri(builder.Configuration["Endpoints:NovanetAPI"]);
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedOrderData();

app.Run();

public static class ServiceConfiguration
{
    public static void SeedOrderData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OrderContext>();

        var storeGuid = Guid.NewGuid();
        var customerId = Guid.NewGuid();
        
        dbContext.Orders.Add(new OrderMemento
        {
            Id = storeGuid,
            Total = 100,
            OrderType = "Dagligvare",
            CustomerId = customerId,
            OrderLines = new List<OrderLineMemento>
            {
                new OrderLineMemento
                {
                    Id = Guid.NewGuid(),
                    Cost = 50,
                    Quantity = 1,
                    ProductId = 1,
                    ProductName = "Melk",
                    WeightPerUnit = 10,
                    WeightTotal = 10
                }
            }
        });

        dbContext.Customers.Add(new CustomerMemento
        {
            Id = customerId,
            Name = "Ola Nordmann",
            Address = "Osloveien 1",
            City = "Oslo",
            Zip = "1234"
        });

        dbContext.SaveChanges();
    }
}

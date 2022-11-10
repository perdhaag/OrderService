using System.Reflection;
using Novanet.OrderService.Application.Commands.Order;
using Novanet.OrderService.Application.Commands.OrderLine;
using Novanet.OrderService.Application.Queries.Order.Query;
using Novanet.OrderService.Customer;
using Novanet.OrderService.Domain.Interfaces;
using Novanet.OrderService.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//Bør vel ha et interface her med en customer implementasjon. 
builder.Services.AddTransient<OrderCommands>();
builder.Services.AddTransient<OrderQueries>();
builder.Services.AddTransient<OrderLineCommands>();
builder.Services.AddTransient<ICustomerClient, CustomerClient>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddHttpClient<ICustomerClient>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration["Endpoints:NovanetAPI"]);
});

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

app.Run();
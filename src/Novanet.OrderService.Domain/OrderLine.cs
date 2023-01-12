using Novanet.OrderService.Domain.Mementos;

namespace Novanet.OrderService.Domain;

public class OrderLine : IHaveState<OrderLineMemento>
{
    public OrderLine(int productId, string? productName, decimal cost, decimal quantity)
    {
        ProductId = productId;
        ProductName = productName;
        Cost = cost;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public int ProductId { get; }
    public string? ProductName { get; }
    public decimal Quantity { get; }
    public decimal WeightPerUnit { get; private set; }
    public decimal WeightTotal { get; private set; }
    public decimal Cost { get; private set; }
    
    
    public void SetProductCost(decimal cost)
    {
        Cost = cost;
    }

    public void SetProductTotalWeight(decimal weightTotal)
    {
        WeightTotal = weightTotal;
    }

    public OrderLineMemento State => new()
    {
        Id = Id,
        ProductId = ProductId,
        ProductName = ProductName,
        Quantity = Quantity,
        WeightPerUnit = WeightPerUnit,
        WeightTotal = WeightTotal,
        Cost = Cost
    };
}
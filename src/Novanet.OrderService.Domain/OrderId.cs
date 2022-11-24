namespace Novanet.OrderService.Domain;

public record OrderId(Guid Value) : ValueObject<Guid>(Value)
{
    public static OrderId NewId() => new(Guid.NewGuid());
}
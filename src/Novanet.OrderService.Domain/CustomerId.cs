namespace Novanet.OrderService.Domain;

public record CustomerId(Guid Value) : ValueObject<Guid>(Value);
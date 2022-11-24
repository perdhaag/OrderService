namespace Novanet.OrderService.Domain;

public record CustomerName(string value) : ValueObject<string>(value);
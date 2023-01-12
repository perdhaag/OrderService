namespace Novanet.OrderService.Domain;

public record CustomerZip(string Value) : ValueObject<string>(Value);
namespace Novanet.OrderService.Domain;

public record CustomerAddress(string Value) : ValueObject<string>(Value);
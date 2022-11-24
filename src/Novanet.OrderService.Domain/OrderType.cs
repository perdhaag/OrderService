namespace Novanet.OrderService.Domain;

public record OrderType(string Value) :  ValueObject<string>(Value);
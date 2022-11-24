namespace Novanet.OrderService.Domain;

public abstract record ValueObject<T>(T Value)
{
    public static implicit  operator T?(ValueObject<T>? obj)
    {
        return obj == null ? default : obj.Value;
    }
}
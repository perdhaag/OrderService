namespace Novanet.OrderService.Domain;

public static class ValueObjectExtensions
{
    public static T To<T>(this Guid value) where T : ValueObject<Guid> =>
        value.To<T, Guid>();
    public static T To<T>(this int value) where T : ValueObject<int> =>
        value.To<T, int>();
    public static T To<T>(this string value) where T : ValueObject<string> =>
        value.To<T, string>();


    private static TType To<TType, TValue>(this TValue value) where TType : ValueObject<TValue>
    {
        var obj = (TType)Activator.CreateInstance(typeof(TType), value)!;

        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        return obj;
    }
}
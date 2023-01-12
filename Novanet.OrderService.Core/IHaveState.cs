namespace Novanet.OrderService.Domain;

public interface IHaveState<out T>
{
    T State { get; }
}
namespace Novanet.OrderService.Domain.Helpers;

public static class FreightCalculator
{
    public static decimal Calculate(string zipCode, decimal weight)
    {
        decimal freight = 0;

        if (weight < 1)
        {
            freight = 39;

            // For Norway North
            if (int.Parse(zipCode) > 9000) freight = 59;
        }
        else if (weight < 2)
        {
            freight = 49;

            // For Norway North
            if (int.Parse(zipCode) > 9000) freight = 69;
        }

        return freight;
    }
}
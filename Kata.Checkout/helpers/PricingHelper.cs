namespace Kata.Checkout.helpers;

public static class PricingHelper
{
    private static readonly Dictionary<string, int> Prices =
        new()
        {
            { "A", 50 },
            { "B", 40 },
            { "C", 30 },
            { "D", 10 },
            
        };
    
    
    public static int GetPrice(string item)
    {
        return Prices[item];
    }
}
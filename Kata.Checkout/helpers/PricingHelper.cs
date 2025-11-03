using Kata.Checkout.PricingRules;

namespace Kata.Checkout.helpers;

public static class PricingHelper
{
    private static readonly Dictionary<string, IPricingRule> Prices =
        new()
        {
            { "A", new UnitPriceRule(50) },
            { "B", new UnitPriceRule(40) },
            { "C", new UnitPriceRule(30) },
            { "D", new UnitPriceRule(20) },
            
        };
    
    
    public static IPricingRule GetRule(string sku)
    {
        if (!Prices.TryGetValue(sku, out var rule))
            throw new KeyNotFoundException($"Unknown SKU: {sku}");

        return rule;
    }
}
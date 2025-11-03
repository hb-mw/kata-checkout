using Kata.Checkout.PricingRules;

namespace Kata.Checkout.helpers;

/// <summary>
/// Represents a pricing catalogue that manages a collection of pricing rules
/// for different SKUs (Stock Keeping Units).
/// This catalogue allows retrieval of pricing rules associated with specific SKUs.
/// </summary>
public class PricingCatalogue(Dictionary<string, IPricingRule> rules)
{
    private readonly Dictionary<string, IPricingRule> _rules = new(rules, StringComparer.Ordinal);

    public IPricingRule GetRule(string sku)
    {
        if (!_rules.TryGetValue(sku, out var rule))
            throw new KeyNotFoundException($"Unknown SKU: {sku}");

        return rule;
    }
}
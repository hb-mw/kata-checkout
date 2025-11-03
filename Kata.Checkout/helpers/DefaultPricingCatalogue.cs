using Kata.Checkout.PricingRules;

namespace Kata.Checkout.helpers;

public static class DefaultPricingCatalogue
{
    /// <summary>
    /// Returns the default catalogue of SKUs and their pricing rules.
    /// </summary>
    public static PricingCatalogue Create()
    {
        return new PricingCatalogue(new Dictionary<string, IPricingRule>
        {
            ["A"] = new MultiBuyOfferRule(50, 3, 130),
            ["B"] = new MultiBuyOfferRule(40, 2, 50),
            ["C"] = new BuyOneGetOneFreeRule(30),
            ["D"] = new UnitPriceRule(20),
        });
    }
}
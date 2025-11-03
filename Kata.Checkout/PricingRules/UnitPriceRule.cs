namespace Kata.Checkout.PricingRules;

public class UnitPriceRule(int unitPrice) : IPricingRule
{
    public int Calculate(int quantity)
    {
        return unitPrice * quantity;
    }
}
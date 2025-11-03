namespace Kata.Checkout.PricingRules;

/// <summary>
/// Represents a pricing rule that calculates the total price based on a unit price per item.
/// </summary>
public class UnitPriceRule(int unitPrice) : IPricingRule
{
    public int Calculate(int quantity)
    {
        return unitPrice * quantity;
    }
}
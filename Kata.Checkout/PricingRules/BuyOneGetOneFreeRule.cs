namespace Kata.Checkout.PricingRules;

/// <summary>
/// Represents a pricing rule that applies a "Buy One Get One Free" offer to an item
/// for calculating the total price based on the specified quantity.
/// </summary>
/// <remarks>
/// For every two items purchased, the cost is equivalent to the price of one item.
/// Additional items beyond complete pairs are charged at the unit price.
/// </remarks>
public class BuyOneGetOneFreeRule(int unitPrice) : IPricingRule
{
    public int Calculate(int quantity)
    {
        int pairs = quantity / 2;
        
        int leftover = quantity % 2;
        
        int totalPaidItems = pairs + leftover;
        
        return totalPaidItems * unitPrice;
    }
}
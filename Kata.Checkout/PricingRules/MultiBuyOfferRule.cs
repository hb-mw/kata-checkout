namespace Kata.Checkout.PricingRules;

/// <summary>
/// Represents a pricing rule that provides a special "multi-buy" offer for certain quantities of an item.
/// For a specified number of items, a discounted price is applied, while remaining items are charged at the regular unit price.
/// </summary>
/// <param name="unitPrice">The unit price of the item when no discounts are applied.</param>
/// <param name="discountedQuantity">The quantity of items required to qualify for the discounted price.</param>
/// <param name="discountedPrice">The total price for the specified discounted quantity of items.</param>
/// <remarks>
/// This rule calculates the total price by determining the number of discounted bundles (groups meeting the discounted quantity),
/// and applying the discounted price to those bundles. Any remaining items (not part of a bundle) are charged at the regular unit price.
/// </remarks>
public class MultiBuyOfferRule(int unitPrice, int discountedQuantity, int discountedPrice) : IPricingRule
{
    public int Calculate(int quantity)
    {
        var bundle = quantity / discountedQuantity;
        
        var leftovers = quantity % discountedQuantity;
        
        var bundlePrice = bundle * discountedPrice;
        var leftoverPrice = leftovers * unitPrice;
        var totalPrice = bundlePrice + leftoverPrice;

        return totalPrice;
    }
}
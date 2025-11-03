namespace Kata.Checkout.PricingRules;

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
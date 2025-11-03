namespace Kata.Checkout.PricingRules;

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
using Kata.Checkout.helpers;

namespace Kata.Checkout;

public class CheckoutService : ICheckoutService
{
    
    private readonly Dictionary<string, int> _itemCounts = new(StringComparer.Ordinal);
    
    public void Scan(string item)
    {
        _itemCounts[item] = _itemCounts.GetValueOrDefault(item, 0) + 1;
    }

    public int GetTotalPrice()
    {
        return _itemCounts.Sum(item => PricingHelper.GetRule(item.Key).Calculate(item.Value));
    }
}
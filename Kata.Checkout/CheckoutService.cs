using Kata.Checkout.helpers;

namespace Kata.Checkout;

public class CheckoutService : ICheckoutService
{
    private List<string> _items = [];
    public void Scan(string item)
    {
        _items.Add(item);
    }

    public int GetTotalPrice()
    {
        return _items.Sum(item => PricingHelper.GetPrice(item));
    }
}
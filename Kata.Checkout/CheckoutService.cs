namespace Kata.Checkout;

public class CheckoutService : ICheckoutService
{
    public void Scan(string item)
    {
        Console.WriteLine("scanned: " + item);
    }

    public int GetTotalPrice()
    {
        return 0;
    }
}
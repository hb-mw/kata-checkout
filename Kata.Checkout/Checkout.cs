namespace Kata.Checkout;

public class Checkout : ICheckout
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
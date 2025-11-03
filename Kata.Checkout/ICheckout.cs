namespace Kata.Checkout;

public interface ICheckout
{
    /// <summary>
    /// Scans an item and adds it to the checkout process.
    /// </summary>
    /// <param name="item">The identifier or code of the item to be scanned into the checkout system.</param>
    void Scan(string item);

    /// <summary>
    /// Calculates and retrieves the total price of all scanned items with.
    /// </summary>
    /// <returns>The total price of items as an integer.</returns>
    int GetTotalPrice();
}
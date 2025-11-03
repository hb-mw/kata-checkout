namespace Kata.Checkout.PricingRules;

public interface IPricingRule
{
    /// <summary>
    /// Calculates the total price based on the specified quantity with respect to the rule.
    /// </summary>
    /// <param name="quantity">The quantity of items to calculate the total price for.</param>
    /// <returns>The calculated total price as an integer.</returns>
    int Calculate(int quantity);
}
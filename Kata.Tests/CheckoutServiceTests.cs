using Kata.Checkout;

namespace Kata.Tests;

public class Tests
{
    private ICheckout checkoutService;
    
    [SetUp]
    public void Setup()
    {
        checkoutService = new Checkout.Checkout();
    }

    [Test]
    public void Empty_Basket_Should_Return_Zero_Total_Price()
    {
        var totalPrice = checkoutService.GetTotalPrice();

        Assert.That(totalPrice, Is.EqualTo(0));
    }
}
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
    public void Test1()
    {
        Assert.Pass();
    }
}
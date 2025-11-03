using Kata.Checkout;

namespace Kata.Tests;

public class Tests
{
    private ICheckoutService _checkoutService;
    
    [SetUp]
    public void Setup()
    {
        _checkoutService = new CheckoutService();
    }

    [Test]
    public void Empty_Basket_Should_Return_Zero_Total_Price()
    {
        var totalPrice = _checkoutService.GetTotalPrice();

        Assert.That(totalPrice, Is.EqualTo(0));
    }
    
    [Test]
    public void SingleItem_A_ShouldReturn50()
    {
        _checkoutService.Scan("A");
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(50));
    }
    
    [Test]
    public void Multi_Items_A_B_ShouldReturn90()
    {
        _checkoutService.Scan("A");
        _checkoutService.Scan("B");
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(90));
    }
    
    [Test]
    public void Single_Unknown_Item_ShouldReturnZero()
    {
        _checkoutService.Scan("z");
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(0));
    }
}
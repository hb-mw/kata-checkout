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
    public void Single_Unknown_Item_Should_Throw_KeyNotFoundException()
    {
        _checkoutService.Scan("z");
        Assert.Throws<KeyNotFoundException>(() => _checkoutService.GetTotalPrice());
    }

    [Test]
    public void Scanning_AA_ShouldReturn100()
    {
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(100));
    }
    
    [Test]
    public void Scanning_AAA_ShouldReturn130()
    {
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(130));
    }
    
    [Test]
    public void Scanning_AAAA_ShouldReturn180()
    {
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(180));
    }
    
    [Test]
    public void Scanning_AAA_B_ShouldReturn170()
    {
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("B");

        var total = _checkoutService.GetTotalPrice();

        Assert.That(total, Is.EqualTo(170));
    }
    
    [Test]
    public void Scanning_AAA_BB_ShouldReturn180()
    {
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("B");
        _checkoutService.Scan("B");

        var total = _checkoutService.GetTotalPrice();

        Assert.That(total, Is.EqualTo(180));
    }

    [Test]
    public void Scanning_CC_ShouldReturn30()
    {
        _checkoutService.Scan("C");
        _checkoutService.Scan("C");
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(30));
    }
    
    [Test]
    public void Scanning_AAA_BB_CC_ShouldReturn210()
    {
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("A");
        _checkoutService.Scan("B");
        _checkoutService.Scan("B");
        _checkoutService.Scan("C");
        _checkoutService.Scan("C");
        
        var totalPrice = _checkoutService.GetTotalPrice();
        
        Assert.That(totalPrice, Is.EqualTo(210));
    }
}
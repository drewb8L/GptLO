using NUnit.Framework;
using Scratch.InventorySystem;
using Scratch.InventorySystem.Factories;

namespace Scratch.Tests;

[TestFixture]
public class UnitTests
{
    private IProduct _stdProduct;
    private IProduct _perishableProduct;
    private IProduct _noDiscount;
    private IProduct _fivePercentDiscount;
    private IProduct _fifteenPercentDiscount;
    private PerishableProduct? _expiredProduct;
    
    
    
    
    [SetUp]
    public void SetUp()
    {
        _stdProduct = ProductFactory.CreateProduct("Std Product", 10, 199.99m);
        _perishableProduct = ProductFactory.CreateProduct("Perishable Product", new DateOnly(2024,07,30), 200, 0.99m);
        
        _noDiscount = ProductFactory.CreateProduct("Perishable Product", DateOnly.FromDateTime(DateTime.Today.AddDays(10)), 200, 100.00m);
        _fivePercentDiscount= ProductFactory.CreateProduct("Perishable Product", DateOnly.FromDateTime(DateTime.Today.AddDays(4)), 200, 100.00m);
        _fifteenPercentDiscount = ProductFactory.CreateProduct("", DateOnly.FromDateTime(DateTime.Today), 200, 100.00m);
        
        _noDiscount.CalculateDiscount();
        _fivePercentDiscount.CalculateDiscount();
        _fifteenPercentDiscount.CalculateDiscount();

        _expiredProduct =
            ProductFactory.CreateProduct("Expired Product", DateOnly.FromDateTime(DateTime.Today.AddDays(-2)), 10,
                9.00m) as PerishableProduct;

    }
    
    [Test]
    public void ProductNotNull()
    {
        Assert.That(_stdProduct, Is.Not.Null);
        Assert.That(_perishableProduct, Is.Not.Null);
    }
    
    [Test]
    public void IsCorrectDiscountApplied()
    {
       Assert.That(_noDiscount.DiscountPrice, Is.EqualTo(0));
       Assert.That(_fivePercentDiscount.DiscountPrice, Is.EqualTo(95m));
       Assert.That(_fifteenPercentDiscount.DiscountPrice, Is.EqualTo(85m));
    }
    
    [Test]
    public void IsExpired()
    {
        _expiredProduct!.CheckAndSetExpired();
        Assert.That(_expiredProduct.Price, Is.EqualTo(0));
        Assert.That(_expiredProduct.Expired, Is.True);
    }
}
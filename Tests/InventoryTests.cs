using Xunit;
using Scratch.InventorySystem;


namespace Tests;

public class InventoryTests
{
    [Fact]
    public void Test1()
    {
        var product = new Product("Computer", 12, 199.99m);
        Assert.NotNull(product);
        Xunit.Assert.Equal("Computer",product.Name);
        Assert.Equal(199.99m, product.Price);
    }
}
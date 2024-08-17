namespace Scratch.InventorySystem.Factories;



public static class ProductFactory
{
    public static IProduct CreateProduct(string name, int quantity = 0, decimal price = 0.0m )
    {
        return new StandardProduct(name, quantity, price);
    }

    public static IProduct CreateProduct(string name, DateOnly exp, int quantity = 0, decimal price = 0.0m )
    {
        return new PerishableProduct(name, exp, quantity, price);
    }
}
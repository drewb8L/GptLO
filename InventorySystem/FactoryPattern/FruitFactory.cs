namespace Scratch.InventorySystem.FactoryPattern;

public static class FruitFactory
{
    public static IFruit CreateFruit(string fruit, string name, DateOnly exp)
    {
        switch (fruit.Trim().ToLower())
        {
            case "apple":
                return new Apple(name, exp);
            case "banana":
                return new Banana(name, exp);
            default:
                throw new ApplicationException("No such fruit: " + fruit);
        }
    }
}
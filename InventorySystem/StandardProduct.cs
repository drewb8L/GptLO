using Scratch.InventorySystem.Factories;

namespace Scratch.InventorySystem;

public class StandardProduct : Product
{

    public StandardProduct(string name, int quantity = 0, decimal price = 0.0m):base(name, quantity, price)
    {
        Name = name;
    }
    
    
    // public string Name { get; set; }
    // public decimal Price { get; set; }
    // public int Quantity { get; set; }
    // public Guid ProductIdentifier { get; }
    

    public override void CalculateDiscount()
    {
        throw new NotImplementedException();
    }
}
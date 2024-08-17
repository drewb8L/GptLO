namespace Scratch.InventorySystem.Factories;

public interface IProduct
{
    
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Guid ProductIdentifier { get; }
    
    public decimal DiscountPrice { get; }
    public void CalculateDiscount();
}
using Scratch.InventorySystem.Factories;

namespace Scratch.InventorySystem;

public abstract class Product : IProduct
{
    protected Product(string name, int quantity = 0, decimal price = 0.0m)
    {
        Name = name;
        ProductIdentifier = Guid.NewGuid();
        Price = price;
        Quantity = quantity;
    }
    
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Guid ProductIdentifier { get; }
    
    public decimal DiscountPrice { get; set; }
    
    public abstract void CalculateDiscount(); //TODO: See about Strategy Pattern on this

    public virtual void SetPrice(decimal price)
    {
      Price = price < 0 ? throw new Exception("Price must be positive integer"): Price = price;
    }
    
    public virtual void SetQuantity(int quantity) {
        if (quantity < 0)
        {
            throw new Exception("Quantity must be positive integer");
        }

        Quantity = quantity;
    }

   
    public override string ToString()
    {
        return $"""
                =============================================
                 Product Name:               {Name}
                 Product Price:              ${Price}
                 Product Stock Quantity:     {Quantity}
                 Product Identifier          {ProductIdentifier}
                =============================================
                """;
    }
}
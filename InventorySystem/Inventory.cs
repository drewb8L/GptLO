using Scratch.InventorySystem.Factories;

namespace Scratch.InventorySystem;

public class Inventory
{
    public Inventory(string inventoryName)
    {
        InventoryName = inventoryName;
    }

    public string InventoryName { get; set; }

    private List<IProduct> Products { get; set; } = new();

    public int ProductCount => Products.Count;

    public void AddProduct(IProduct? product)
    {
        if (product is null)
        {
            throw new NullReferenceException("Product is null.");
        }
        Products.Add(product);
        
        Console.WriteLine($"{product.Name} added to {InventoryName}");
    }

    public void AddProducts(List<IProduct> products)
    {
        if (products is null)
        {
            throw new NullReferenceException("Product is null.");
        }

        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    public void UpdateProduct(string sku, string name = "", decimal price = -1.0m, int quantity = -1)
    {
        var product = Products.Find(pr => pr.ProductIdentifier.ToString() == sku);
        if (product is null)
        {
            throw new NullReferenceException("Product is null.");
        }

        if (name == "" && price == -1.0m && quantity == -1)
        {
            throw new ArgumentException("Arguments have not been provided.");
        }

        if (name != "")
        {
            product.Name = name;
        }
        if (price >= 0.0m)
        {
            product.Price = price;
            
        }
        else
        {
            throw new ArgumentException("Price can not be negative.");
        }
        
        if (quantity >= 0.0m)
        {
            product.Quantity = quantity;
        }
        else
        {
            throw new ArgumentException("Quantity can not be negative!");
        }
        
        // product = Products.Find(pr => pr.ProductIdentifier.ToString() == sku);
        
        
    }

    public void RemoveProduct(IProduct product)
    {
        if (product is null)
        {
            throw new NullReferenceException("Product is null.");
        }

        var productToRemove = Products.Find(p => 
            p.ProductIdentifier == product.ProductIdentifier);
        if (productToRemove is null)
        {
            throw new NullReferenceException("This product does not exist");
        }
        
        Products.Remove(productToRemove);
        Console.WriteLine($"Removed {product.Name} from Inventory");
    }

    public void DisplayAllProducts()
    {
        Console.WriteLine($"{InventoryName}'s Products:");
        Console.WriteLine($"Product Count: {Products.Count}");
        foreach (var product in Products)
        {
            
            Console.WriteLine(product.ToString());
        }
    }
}
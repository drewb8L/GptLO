using Scratch.InventorySystem.Factories;
using Scratch.InventorySystem.Services;

namespace Scratch.InventorySystem;

// TODO: Refactor to use service
public class Inventory
{
    private readonly IProductService _productService;
    public Inventory(string inventoryName, IProductService productService)
    {
        InventoryName = inventoryName;
        _productService = productService;
    }

    public string InventoryName { get; set; }

    private List<IProduct> Products { get; set; } = new();

    public int ProductCount => Products.Count;

    public IProduct AddProduct(ProductType type, string[]productParams)
    {
        var product = _productService.AddProduct(type, productParams);
        if (product is null)
        {
            throw new NullReferenceException("Product is null.");
        }
        Products.Add(product);
        
        Console.WriteLine($"{product.Name} added to {InventoryName}");
        return product;
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

    public bool UpdateProduct(string sku, string name = "", int quantity = -1,decimal price = -1.0m)
    {
        var product = Products.Find(pr => pr.ProductIdentifier.ToString() == sku);
        if (product is null)
        {
            Console.WriteLine("Product is null.");
            return false;
        }

        if (name == "" && price == -1.0m && quantity == -1)
        {
            Console.WriteLine("Arguments have not been provided.");
            return false;
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
            
            Console.WriteLine("Price can not be negative.");
            return false;
        }
        
        if (quantity >= 0.0m)
        {
            product.Quantity = quantity;
            return true;
        }
        else
        {
            Console.WriteLine("Quantity can not be negative!");
            return false;
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
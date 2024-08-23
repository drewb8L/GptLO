using System.Threading.Channels;
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

    public void AddProduct(ProductType type, string[]productParams)
    {
        try
        {
            var product = _productService.CreateProduct(type, productParams);
            
            Products.Add(product);
          
            Console.WriteLine($"{product.Name} added to {InventoryName}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }

    public bool AddProducts(List<IProduct> products)
    {
        try
        {
            Products.AddRange(products);
            return true;
        }
        catch( NullReferenceException e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool UpdateProduct(string sku, string name = "", int quantity = -1,decimal price = -1.0m)
    {
        //TODO: Maybe refactor to try/catch 
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

    public bool RemoveProduct(string sku)
    {
        try
        {
            var product = Products.Find(p =>
                sku == p.ProductIdentifier.ToString());

            if (product is not null)
            {
                Products.Remove(product);
                Console.WriteLine($"{product.Name} removed from {InventoryName}");
            }

            return true;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool FindProduct(string sku)
    {
        try
        {
            var product = Products.Find(pr => pr.ProductIdentifier.ToString() == sku);
            Console.WriteLine(product?.ToString());
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }
    public void DisplayAllProducts()
    {
        // TODO: Update discount on display
        Console.WriteLine($"{InventoryName}'s Products:");
        Console.WriteLine($"Product Count: {Products.Count}");
        foreach (var product in Products)
        {
            
            Console.WriteLine(product.ToString());
        }
    }
}
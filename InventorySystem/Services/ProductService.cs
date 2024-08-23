using Scratch.InventorySystem.Factories;

namespace Scratch.InventorySystem.Services;

public enum ProductType
{
    Standard,
    Perishable,
}

public class ProductService : IProductService
{
    private static string name;
    private static int quantity;
    private static decimal price;
    private static DateOnly expiration;
    private static bool _isValidProduct;

    static void ParseInput(Dictionary<string, string> pd)
    {
        try
        {
            name = pd["name"];

            quantity = int.Parse(pd["quantity"]);

            price = decimal.Parse(pd["price"]);

            expiration = pd.ContainsKey("exp") ? DateOnly.Parse(pd["exp"]) : new DateOnly();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        _isValidProduct = true;
    }
    private static void ValidateProduct(string[] productParams)
    {
        var pd = new Dictionary<string, string>
        {
            { "name", productParams[0] },
            { "quantity", productParams[1] },
            { "price", productParams[2] }
        };

        if (productParams.Length > 3)
        {
            pd.Add("exp", productParams[3]);
        }
        
        try
        {
            ParseInput(pd);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Please correct the input");
            _isValidProduct = false;
        }
    }


    public IProduct CreateProduct(ProductType type, string[]productParams )
    {
        ValidateProduct(productParams);
        
        switch (_isValidProduct)
        {
            case true when type == ProductType.Standard:
                Console.WriteLine("creating new standard product...");
                return ProductFactory.CreateProduct(name: name, quantity: quantity, price: price);
            case true when type == ProductType.Perishable:
                Console.WriteLine("Creating new perishable product");
                return ProductFactory.CreateProduct(name: name, quantity: quantity, price: price, exp:expiration);
            default:
                throw new Exception("You Fucked Up!");
        }
    }

    public bool RemoveProduct(string sku)
    {
        
        return false;
    }
    

    public bool UpdateProduct(string sku, string name, int quantity, decimal price, Inventory inventory)
    {
        var result = false;
        return result = inventory.UpdateProduct(sku, name, quantity, price);
        
    }
}
using Scratch.InventorySystem.Factories;

namespace Scratch.InventorySystem.Services;

public interface IProductService
{
    IProduct AddProduct(ProductType type, string[]productParams );
    bool RemoveProduct();
    bool UpdateProduct(string sku, string name, int quantity, decimal price, Inventory inventory);
    
}
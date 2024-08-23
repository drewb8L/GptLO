using Scratch.InventorySystem.Factories;

namespace Scratch.InventorySystem.Services;

public interface IProductService
{
    IProduct CreateProduct(ProductType type, string[]productParams );
    bool RemoveProduct(string sku);
    bool UpdateProduct(string sku, string name, int quantity, decimal price, Inventory inventory);
    
}
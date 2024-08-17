using Scratch.InventorySystem.Factories;

namespace Scratch.InventorySystem.Commands;

public interface ICommand
{
    public void Execute();
}

public class CreateProductCommand : ICommand
{
    private readonly string _name;
    private readonly decimal _price;
    private readonly int _quantity;
    private IProduct _product;
    
    public CreateProductCommand(ref IProduct product, string name, int quantity, decimal price)
    {
        _name = name;
        _price = price;
        _quantity = quantity;
        _product = product;
        // Console.WriteLine(_product.ToString());
    }
    public void Execute()
    {
      _product = ProductFactory.CreateProduct(_name, _quantity, _price);
      
    }
}


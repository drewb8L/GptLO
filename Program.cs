using System.Diagnostics;
using Scratch.InventorySystem;
using Scratch.InventorySystem.Factories;
using Scratch.InventorySystem.FactoryPattern;
using Scratch.InventorySystem.Commands;



Console.WriteLine("Welcome to Inventory Manager");

var exit = false;

Inventory inventory = null;
IProduct product = null;
List<IProduct> products = new();

void Menu()
{
    while (!exit)
    {
        Console.WriteLine("Choose an option from the following list:");
        Console.WriteLine("\tc - Create new inventory");
        Console.WriteLine("\td - Display inventory and it's Products");
        Console.WriteLine("\ta - Add a Product to an inventory");
        Console.WriteLine("\tf - Find a Product by sku");
        Console.WriteLine("\tu - Update a Product");
        Console.WriteLine("\tr - Remove a Product");
        Console.Write("Your option?  ");
        
        var choice = Console.ReadLine();

        switch (choice?.Trim().ToLower())
        {
            case "exit":
                Console.WriteLine("Exiting...");
                exit = true;
                break;
            case "c":
                Console.WriteLine("Creating new Inventory");
                InventoryMenu();
                break;
            case "d":
                Console.WriteLine("Displaying Inventory");
                inventory?.DisplayAllProducts();
                break;
            case "a":
                Console.WriteLine("Creating new Product");
                ProductMenu();
                break;
            case "f":
                Console.WriteLine("Find a Product");
                break;
            case "u":
                Console.WriteLine("Update a Product");
                break;
            case "r":
                Console.WriteLine("Remove a Product");
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
        
    }
}

void InventoryMenu()
{
    var exit = false;
    while (!exit)
    { 
        Console.WriteLine("Name your Inventory: ");
        var name = Console.ReadLine();
        if (name != string.Empty)
        {
            inventory = new Inventory(name!.Trim());
            exit = true;
            break;
        }
        Console.WriteLine("Please provide an Inventory name");
    }
}

void ProductMenu()
{
    var exit = false;
    string name = "";
    int quantity = 0;
    decimal price = 0.0m;
    
    while (!exit)
    { 
        //TODO: YEET this code!
        Console.WriteLine("Create a new Product: ");
        Console.WriteLine("Enter the products Name Quantity and Price: ");
        var properties = Console.ReadLine();
        if (properties != string.Empty)
        {
            var results = properties.Split(" ");

            if (name != string.Empty)
            {
                name = results[0];
            }
            else if(results[1] is int)
            {
                quantity = int.Parse(results[1]);
            }
            else if (results[2] is decimal)
            {
                price = decimal.Parse(results[2]);
            }
            else
            {
                Console.WriteLine("Incorrect params");
                continue;
            }
            
           
        }
        product = ProductFactory.CreateProduct(name, quantity, price);
        inventory?.AddProduct(product);

        exit = true;
        break;
        
        Console.WriteLine("Please provide an Inventory name");
    }
}

Menu();

using Scratch.InventorySystem;
using Scratch.InventorySystem.Factories;
using Scratch.InventorySystem.Services;


Console.WriteLine("Welcome to Inventory Manager");

var exit = false;

Inventory inventory = null;
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
        Console.WriteLine("\tq - Quit program");
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
                AddProductMenu();
                break;
            case "f":
                Console.WriteLine("Find a Product");
                FindProductMenu();
                break;
            case "u":
                Console.WriteLine("Update a Product");
                UpdateProductMenu();
                break;
            case "r":
                Console.WriteLine("Remove a Product");
                RemoveProduct();
                break;
            case "q":
                Console.WriteLine("Exiting Program");
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
        
    }
    
}
Menu();

void InventoryMenu()
{
    var exitMenu = false;
    
    while (!exitMenu)
    { 
        Console.WriteLine("Name your Inventory: ");
        var name = Console.ReadLine();
        if (name == string.Empty)
        {
            Console.WriteLine("Please provide an Inventory name");
            continue;
        }
        inventory = new Inventory(name!.Trim(), new ProductService());
        exitMenu = true;
    }
}

void AddProductMenu()
{
    var exitMenu = false;
    DateOnly expDate = default;
    while (exitMenu == false)
    { 
        Console.WriteLine("Create a new Product: ");
        Console.WriteLine("Is this a perishable product? Enter for no or y for yes: ");
        var type = Console.ReadLine().Trim().ToLower();
        if (type == "y")
        {
            Console.WriteLine("Enter an expiration date in yyyy/mm/dd format");
            var date = Console.ReadLine();
            if (!DateOnly.TryParse(date!, out expDate))
            {
                Console.WriteLine("Please provide a valid date");
                //continue; ?
            }
            
        }
        
        Console.WriteLine("Enter the products Name Quantity and Price: ");
        var properties = Console.ReadLine();
        var productParams = properties.Split(" ").ToList();
        
        if (properties == string.Empty)
        {
            Console.WriteLine(" No product data provided. Please enter a product");
            continue;
        }
        
        // productParams.Add(expDate.ToString());
        Console.WriteLine(productParams.Count);
        if (expDate > DateOnly.FromDateTime(DateTime.Now))
        {
            productParams.Add(expDate.ToString());
            inventory?.AddProduct(ProductType.Perishable, productParams.ToArray());
        }
        else
        {
            inventory?.AddProduct(ProductType.Standard, productParams.ToArray());
        }

        
        exitMenu = true;
    }
    
}

void UpdateProductMenu()
{
    var exitMenu = false;
    while (!exitMenu)
    {
        Console.WriteLine("Update a Product: ");
        Console.WriteLine("Enter the product SKU: ");
        var sku = Console.ReadLine();
        if (sku == String.Empty)
        {
            Console.WriteLine("Please enter a sku");
            continue;
        }

        Console.WriteLine("Enter new name, or press enter to skip: ");
        var name = Console.ReadLine();

        Console.WriteLine("Enter new quantity, or press enter to ship: ");
        var quantity = Console.ReadLine();

        Console.WriteLine("Enter new price, or press enter to skip: ");
        var price = Console.ReadLine();

        if (name == string.Empty && quantity == string.Empty && price == string.Empty)
        {
            Console.WriteLine("No values entered, returning to main menu.");
            exitMenu = true;
        }

        int number;
        var isQuantityAnInt = int.TryParse(quantity, out number);
        if (!isQuantityAnInt)
        {
            Console.WriteLine("Not a valid quantity");
                
        }

        decimal priceNumber;
        var isPriceADecimal = decimal.TryParse(price, out priceNumber);
        if (!isPriceADecimal)
        {
            Console.WriteLine("Not a valid price");
        }

        var updateProduct = inventory?.UpdateProduct(sku, name, int.Parse(quantity), decimal.Parse(price));
    }
        
}

void FindProductMenu()
{

    var sku = "";
    while (sku == string.Empty)
    {
        Console.WriteLine("Enter the product SKU: ");
        sku = Console.ReadLine();
         
    }

    if (inventory?.FindProduct(sku!) == false)
    {
        Console.WriteLine("Product not found");
    }
    
}


void RemoveProduct()
{
    var sku = "";
    var product = false;
    while (sku == string.Empty)
    {
        Console.WriteLine("Enter the product SKU: ");
        sku = Console.ReadLine();
         
    }

    if (inventory?.FindProduct(sku!) == false)
    {
        Console.WriteLine("Product not found");
    }
   
}
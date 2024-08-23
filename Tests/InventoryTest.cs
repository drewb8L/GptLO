// using NUnit.Framework;
// using Scratch.InventorySystem;
// using Scratch.InventorySystem.Factories;
//
//
// namespace Scratch;
//
// [TestFixture]
// public class InventoryTest
// {
//     private Inventory _inventory;
//     private List<IProduct> _products;
//     
//     [SetUp]
//     public void SetUp()
//     { 
//         _inventory = new Inventory("Test Inventory");
//         
//         _products = new List<IProduct>
//         {
//             ProductFactory.CreateProduct("Toy Car", 20, 19.99m),
//             ProductFactory.CreateProduct("toy Train", 25, 10.99m),
//         };
//         
//         _inventory.AddProducts(_products);
//     }
//
//     [Test]
//     public void InventoryIsNotNull()
//     {
//         Assert.That(_inventory, Is.Not.Null);
//     }
//
//     [Test]
//     public void AddProductsToInventory()
//     {
//         var product = ProductFactory.CreateProduct("New Product", 10, 9.95m);
//         Assert.That(_inventory.ProductCount, Is.EqualTo(2));
//         
//         _inventory.AddProduct(product);
//         
//         Assert.That(_inventory.ProductCount, Is.EqualTo(3));
//     }
//
//     [Test]
//     public void RemoveProductFromInventory()
//     {
//         var product = ProductFactory.CreateProduct("test", 1, 1.0m);
//         _inventory.AddProduct(product);
//         
//         Assert.That(_inventory.ProductCount, Is.EqualTo(3));
//         
//         _inventory.RemoveProduct(product);
//         
//         Assert.That(_inventory.ProductCount, Is.EqualTo(2));
//     }
//
//     [Test]
//     public void UpdateProduct()
//     {
//         var product = ProductFactory.CreateProduct("new", 1, 10.00m); //TODO: factory accepts negitive values!
//         
//         _inventory.AddProduct(product);
//         
//         _inventory.UpdateProduct(product.ProductIdentifier.ToString(), "Updated Product", 9.99m, 100);
//         
//         Assert.That(product.Name, Is.EqualTo("Updated Product"));
//         Assert.That(product.Price, Is.EqualTo(9.99m));
//         Assert.That(product.Quantity, Is.EqualTo(100));
//     }
//
//     [Test]
//     public void UpdateProductWithInvalidPrice()
//     {
//         var product = ProductFactory.CreateProduct("new", 1, 10.00m);
//         
//         _inventory.AddProduct(product);
//         
//         Assert.Throws<ArgumentException>(() => _inventory.UpdateProduct(product.ProductIdentifier.ToString(), "Updated Product", -2m, 100));
//     }
//
//     [Test]
//     public void UpdateProductWithInvalidQuantity()
//     {
//         var product = ProductFactory.CreateProduct("new", 1, 10.00m);
//         
//         _inventory.AddProduct(product);
//
//         Assert.Throws<ArgumentException>(() =>
//             _inventory.UpdateProduct(product.ProductIdentifier.ToString(), "Updated Product", 2m, -100));
//     }
//     
//
// }
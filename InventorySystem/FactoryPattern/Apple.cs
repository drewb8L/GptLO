namespace Scratch.InventorySystem.FactoryPattern;

public class Apple : Fruit
{
    public Apple(string name, DateOnly exp) : base(name, exp)
    {
        
    }
    
    public override void WhatFlavor()
    {
        Console.WriteLine("Apple flavor");
    }
}
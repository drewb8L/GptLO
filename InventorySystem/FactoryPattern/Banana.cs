namespace Scratch.InventorySystem.FactoryPattern;

public class Banana : Fruit
{
    public Banana(string name, DateOnly exp) : base(name, exp)
    {
    }
    public string Name { get; set; }
    public DateOnly Exp { get; set; }

    public override void WhatFlavor()
    {
        Console.WriteLine("Banana flavor");
    }

    
}
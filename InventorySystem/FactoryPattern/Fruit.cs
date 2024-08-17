namespace Scratch.InventorySystem.FactoryPattern;

public abstract class Fruit: IFruit
{
    public Fruit(string name, DateOnly exp)
    {
        Name = name;
        Exp = exp;
    }
    
    public string Name { get; set; }
    public DateOnly Exp { get; set; }
    public abstract void WhatFlavor();
}
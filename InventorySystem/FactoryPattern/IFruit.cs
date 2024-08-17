namespace Scratch.InventorySystem.FactoryPattern;

public interface IFruit
{
    
    public string Name { get; set; }
    public DateOnly Exp { get; set; }
    public abstract void WhatFlavor();
}
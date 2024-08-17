namespace Scratch;

public class Car : Vehicle
{
    public override void Drive() // Must implement an Override version of Drive, abstract.
    {
        Console.WriteLine("Car is driving");
    }
    
    public override void Horn() //Virtual. Override is implemented, will call parent class implementation if none provided.
    {
        Console.WriteLine("BEEP BEEP");
    }

    public void GetVin(string make)
    {
        Console.WriteLine($"VIN for {make} is 7890789-890-809-0 ");
    }

    public void GetVin(string make, string model)
    {
        Console.WriteLine($"VIN for {make} {model} is 7890789-890-809-0 ");
    }
}
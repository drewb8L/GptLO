namespace Scratch;

public abstract class Vehicle // Base class only
{
    public string Make { get; set; }
    public string Model { get; set; }

    public virtual void SetMake(string make)
    {
        Make = make;
    }

    public abstract void Drive(); // Provide implementation, no body

    public virtual void Horn()
    {
        Console.WriteLine("HONNNNK!");
    }
    
    

}
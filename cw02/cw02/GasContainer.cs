namespace cw02;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; } // Ciśnienie w atmosferach
    
    public GasContainer(double maxLoad, double ownWeight, double height, double depth, double pressure)
        : base("G", maxLoad, ownWeight, height, depth)
    {
        Pressure = pressure;
    }

    public override void Load(double weight)
    {
        if (CurrentLoad + weight > MaxLoad)
        {
            NotifyHazard($"Attempt to overload gas container {SerialNumber}. Max allowed: {MaxLoad - CurrentLoad}kg");
            throw new InvalidOperationException($"Cannot load {weight}kg, max allowed: {MaxLoad - CurrentLoad}kg");
        }
        
        CurrentLoad += weight;
        Console.WriteLine($"Loaded {weight}kg into {SerialNumber}. Current load: {CurrentLoad}kg, Pressure: {Pressure} atm.");
    }

    public override void Unload()
    {
        double remainingLoad = CurrentLoad * 0.05;
        CurrentLoad = remainingLoad;
        Console.WriteLine($"Unloaded {SerialNumber}. Remaining load: {CurrentLoad}kg (5% retained). Pressure: {Pressure} atm.");
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message}");
    }
}
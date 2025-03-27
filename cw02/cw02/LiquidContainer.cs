namespace cw02;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidContainer(double maxLoad, double ownWeight, double height, double depth, bool isHazardous)
        : base("L", maxLoad, ownWeight, height, depth)
    {
        IsHazardous = isHazardous;
    }
    
    public override void Load(double weight)
    {
        double limit = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        
        if (weight > limit)
        {
            NotifyHazard($"Attempt to overload hazardous container {SerialNumber}. Max allowed: {limit}kg");
            return;
        }
        
        base.Load(weight);
    }
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message}");
    }
}
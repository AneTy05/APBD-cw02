namespace cw02;

public class Container
{
    public double MaxLoad { get; } //in kg
    public double CurrentLoad { get; set; } //in kg
    public double Height { get; } //in cm
    public double OwnWeight { get; } //waga samego kontenera, in kg
    public double Depth { get; } //in cm
    public string SerialNumber { get; }
    private static int counter = 1; 
    
    protected Container(string type, double maxLoad, double ownWeight, double height, double depth)
    {
        SerialNumber = $"KON-{type}-{counter++}";
        MaxLoad = maxLoad;
        OwnWeight = ownWeight;
        Height = height;
        Depth = depth;
        CurrentLoad = 0;
    }
    
    public void Load(double weight)
    {
        if (CurrentLoad + weight > MaxLoad)
            throw new InvalidOperationException($"Cannot load {weight}kg, max allowed: {MaxLoad - CurrentLoad}kg");
        
        CurrentLoad += weight;
        Console.WriteLine($"Loaded {weight}kg into {SerialNumber}. Current load: {CurrentLoad}kg.");
    }
    
    public void Unload()
    {
        CurrentLoad = 0;
        Console.WriteLine($"Unloaded {SerialNumber}.");
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Container {SerialNumber}:\n - Own Weight: {OwnWeight}kg\n - Max Load: {MaxLoad}kg\n - Height: {Height}cm\n - Depth: {Depth}cm\n - Cargo Weight: {CurrentLoad}kg");
    }
}
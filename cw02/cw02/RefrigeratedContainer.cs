namespace cw02;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    public double RequiredTemperature { get; }

    public RefrigeratedContainer(double maxLoad, double ownWeight, double height, double depth, string productType, double requiredTemperature)
        : base("R", maxLoad, ownWeight, height, depth)
    {
        ProductType = productType;
        RequiredTemperature = requiredTemperature;
        Temperature = requiredTemperature;
    }

    public void SetTemperature(double temperature)
    {
        if (temperature < RequiredTemperature)
        {
            throw new InvalidOperationException($"Temperature cannot be set below required {RequiredTemperature}°C for {ProductType}.");
        }
        Temperature = temperature;
        Console.WriteLine($"Temperature in {SerialNumber} set to {Temperature}°C.");
    }

    public override void Load(double weight)
    {
        base.Load(weight);
        Console.WriteLine($"Loaded {weight}kg of {ProductType} into {SerialNumber}.");
    }
}
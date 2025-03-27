namespace cw02;

public class Ship
{
    public string Name { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; } // W tonach (1 tona = 1000kg)
    public double MaxSpeed { get; } // Węzły
    public List<Container> Containers { get; }

    public Ship(string name, int maxContainers, double maxWeight, double maxSpeed)
    {
        Name = name;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight * 1000; // Konwersja na kg
        MaxSpeed = maxSpeed;
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new InvalidOperationException("Cannot load more containers, capacity reached.");

        double totalWeight = TotalWeight() + container.OwnWeight + container.CurrentLoad;
        if (totalWeight > MaxWeight)
            throw new InvalidOperationException("Cannot load container, weight limit exceeded.");

        Containers.Add(container);
        Console.WriteLine($"Loaded container {container.SerialNumber} onto {Name}.");
    }
    
    public void LoadMultipleContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            try
            {
                LoadContainer(container);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading container {container.SerialNumber}: {e.Message}");
            }
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        Container container = Containers.Find(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            Console.WriteLine($"Removed container {serialNumber} from {Name}.");
        }
        else
        {
            Console.WriteLine($"Container {serialNumber} not found on {Name}.");
        }
    }
    
    public void ReplaceContainer(string oldSerial, Container newContainer)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == oldSerial);
        if (index != -1)
        {
            Containers[index] = newContainer;
            Console.WriteLine($"Replaced container {oldSerial} with {newContainer.SerialNumber} on {Name}.");
        }
        else
        {
            Console.WriteLine($"Container {oldSerial} not found on {Name}.");
        }
    }
    
    public static void TransferContainer(Ship from, Ship to, string serialNumber)
    {
        Container container = from.Containers.Find(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            Console.WriteLine($"Container {serialNumber} not found on {from.Name}.");
            return;
        }

        try
        {
            from.RemoveContainer(serialNumber);
            to.LoadContainer(container);
            Console.WriteLine($"Transferred container {serialNumber} from {from.Name} to {to.Name}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error transferring container {serialNumber}: {e.Message}");
        }
    }

    public double TotalWeight()
    {
        double weight = 0;
        foreach (var container in Containers)
            weight += container.OwnWeight + container.CurrentLoad;

        return weight;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Ship: {Name}, Max Speed: {MaxSpeed} knots, Max Containers: {MaxContainers}, Max Weight: {MaxWeight / 1000} tons, Current Containers: {Containers.Count}");
        foreach (var container in Containers)
            container.DisplayInfo();
    }
}
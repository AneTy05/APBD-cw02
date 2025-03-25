namespace cw02;

public class Container
{
    public double MaxLoad { get; set; } //in kg
    private double _masaLadunku; //w kilogramach
    private double _wysokosc; //w centymertach
    private double _wagaWlasna; //waga samego kontenera, w kilogramach
    private double _glebokosc; //w centymetrach
    private string _nrSeryjny1 = "CON";
    private string? _nrSeryjny2;
    private static int counter = 0; 
}
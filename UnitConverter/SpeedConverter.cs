using System;

public class SpeedConverter : IConverter
{
    public void Convert()
    {
        Console.WriteLine("Verfügbare Einheiten:");
        Console.WriteLine("1 - Meter pro Sekunde (m/s)");
        Console.WriteLine("2 - Kilometer pro Stunde (km/h)");
        Console.WriteLine("3 - Meilen pro Stunde (mph)");
        Console.WriteLine("4 - Knoten (knot)");

        Console.Write("Quell-Einheit wählen (1-4): ");
        string fromChoice = Console.ReadLine();

        Console.Write("Ziel-Einheit wählen (1-4): ");
        string toChoice = Console.ReadLine();

        if (!IsValidChoice(fromChoice) || !IsValidChoice(toChoice))
        {
            Console.WriteLine("Ungültige Auswahl.");
            return;
        }

        Console.Write("Wert eingeben: ");
        if (!double.TryParse(Console.ReadLine(), out double value))
        {
            Console.WriteLine("Ungültige Zahl.");
            return;
        }

        double mps = ConvertToMps(value, fromChoice);
        double result = ConvertFromMps(mps, toChoice);

        string fromUnit = GetUnitName(fromChoice);
        string toUnit = GetUnitName(toChoice);

        Console.WriteLine($"{value} {fromUnit} = {result:F4} {toUnit}");
    }

    private bool IsValidChoice(string c) => int.TryParse(c, out int n) && n >= 1 && n <= 4;

    private double ConvertToMps(double v, string f) => f switch
    {
        "1" => v,
        "2" => v / 3.6,
        "3" => v * 0.44704,
        "4" => v * 0.514444,
        _ => throw new ArgumentException()
    };

    private double ConvertFromMps(double mps, string t) => t switch
    {
        "1" => mps,
        "2" => mps * 3.6,
        "3" => mps / 0.44704,
        "4" => mps / 0.514444,
        _ => throw new ArgumentException()
    };

    private string GetUnitName(string c) => c switch
    {
        "1" => "m/s",
        "2" => "km/h",
        "3" => "mph",
        "4" => "knot",
        _ => "?"
    };
}

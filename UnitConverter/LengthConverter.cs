using System;

public class LengthConverter : IConverter
{
    public void Convert()
    {
        Console.WriteLine("Verfügbare Einheiten:");
        Console.WriteLine("1 - Millimeter (mm)");
        Console.WriteLine("2 - Zentimeter (cm)");
        Console.WriteLine("3 - Meter (m)");
        Console.WriteLine("4 - Kilometer (km)");
        Console.WriteLine("5 - Inch (in)");
        Console.WriteLine("6 - Fuß (ft)");
        Console.WriteLine("7 - Yard (yd)");
        Console.WriteLine("8 - Meile (mi)");

        Console.Write("Quell-Einheit wählen (1-8): ");
        string fromChoice = Console.ReadLine();

        Console.Write("Ziel-Einheit wählen (1-8): ");
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

        double meters = ConvertToMeters(value, fromChoice);
        double result = ConvertFromMeters(meters, toChoice);

        string fromUnit = GetUnitName(fromChoice);
        string toUnit = GetUnitName(toChoice);

        Console.WriteLine($"{value} {fromUnit} = {result:F6} {toUnit}");
    }

    private bool IsValidChoice(string choice) => int.TryParse(choice, out int n) && n >= 1 && n <= 8;

    private double ConvertToMeters(double value, string fromChoice) => fromChoice switch
    {
        "1" => value / 1000,
        "2" => value / 100,
        "3" => value,
        "4" => value * 1000,
        "5" => value * 0.0254,
        "6" => value * 0.3048,
        "7" => value * 0.9144,
        "8" => value * 1609.344,
        _ => throw new ArgumentException()
    };

    private double ConvertFromMeters(double meters, string toChoice) => toChoice switch
    {
        "1" => meters * 1000,
        "2" => meters * 100,
        "3" => meters,
        "4" => meters / 1000,
        "5" => meters / 0.0254,
        "6" => meters / 0.3048,
        "7" => meters / 0.9144,
        "8" => meters / 1609.344,
        _ => throw new ArgumentException()
    };

    private string GetUnitName(string choice) => choice switch
    {
        "1" => "mm",
        "2" => "cm",
        "3" => "m",
        "4" => "km",
        "5" => "in",
        "6" => "ft",
        "7" => "yd",
        "8" => "mi",
        _ => "?"
    };
}

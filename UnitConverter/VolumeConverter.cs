using System;

public class VolumeConverter : IConverter
{
    public void Convert()
    {
        Console.WriteLine("Verfügbare Einheiten:");
        Console.WriteLine("1 - Milliliter (ml)");
        Console.WriteLine("2 - Liter (l)");
        Console.WriteLine("3 - Kubikmeter (m³)");
        Console.WriteLine("4 - US-Gallonen (gal US)");
        Console.WriteLine("5 - UK-Gallonen (gal UK)");

        Console.Write("Quell-Einheit wählen (1-5): ");
        string fromChoice = Console.ReadLine();

        Console.Write("Ziel-Einheit wählen (1-5): ");
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

        double liters = ConvertToLiters(value, fromChoice);
        double result = ConvertFromLiters(liters, toChoice);

        string fromUnit = GetUnitName(fromChoice);
        string toUnit = GetUnitName(toChoice);

        Console.WriteLine($"{value} {fromUnit} = {result:F6} {toUnit}");
    }

    private bool IsValidChoice(string choice) => int.TryParse(choice, out int n) && n >= 1 && n <= 5;

    private double ConvertToLiters(double value, string from) => from switch
    {
        "1" => value / 1000,
        "2" => value,
        "3" => value * 1000,
        "4" => value * 3.78541,
        "5" => value * 4.54609,
        _ => throw new ArgumentException()
    };

    private double ConvertFromLiters(double l, string to) => to switch
    {
        "1" => l * 1000,
        "2" => l,
        "3" => l / 1000,
        "4" => l / 3.78541,
        "5" => l / 4.54609,
        _ => throw new ArgumentException()
    };

    private string GetUnitName(string c) => c switch
    {
        "1" => "ml",
        "2" => "l",
        "3" => "m³",
        "4" => "gal US",
        "5" => "gal UK",
        _ => "?"
    };
}

using System;

public class AreaConverter : IConverter
{
    public void Convert()
    {
        Console.WriteLine("Verfügbare Einheiten:");
        Console.WriteLine("1 - Quadratmillimeter (mm²)");
        Console.WriteLine("2 - Quadratzentimeter (cm²)");
        Console.WriteLine("3 - Quadratmeter (m²)");
        Console.WriteLine("4 - Hektar (ha)");
        Console.WriteLine("5 - Quadratkilometer (km²)");

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

        double sqm = ConvertToSquareMeters(value, fromChoice);
        double result = ConvertFromSquareMeters(sqm, toChoice);

        string fromUnit = GetUnitName(fromChoice);
        string toUnit = GetUnitName(toChoice);

        Console.WriteLine($"{value} {fromUnit} = {result:F6} {toUnit}");
    }

    private bool IsValidChoice(string c) => int.TryParse(c, out int n) && n >= 1 && n <= 5;

    private double ConvertToSquareMeters(double v, string f) => f switch
    {
        "1" => v / 1_000_000,
        "2" => v / 10_000,
        "3" => v,
        "4" => v * 10_000,
        "5" => v * 1_000_000,
        _ => throw new ArgumentException()
    };

    private double ConvertFromSquareMeters(double sqm, string t) => t switch
    {
        "1" => sqm * 1_000_000,
        "2" => sqm * 10_000,
        "3" => sqm,
        "4" => sqm / 10_000,
        "5" => sqm / 1_000_000,
        _ => throw new ArgumentException()
    };

    private string GetUnitName(string c) => c switch
    {
        "1" => "mm²",
        "2" => "cm²",
        "3" => "m²",
        "4" => "ha",
        "5" => "km²",
        _ => "?"
    };
}

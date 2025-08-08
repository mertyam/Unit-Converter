using System;

public class WeightConverter : IConverter
{
    public void Convert()
    {
        Console.WriteLine("Verfügbare Einheiten:");
        Console.WriteLine("1 - Milligramm (mg)");
        Console.WriteLine("2 - Gramm (g)");
        Console.WriteLine("3 - Kilogramm (kg)");
        Console.WriteLine("4 - Tonne (t)");
        Console.WriteLine("5 - Pfund (lbs)");
        Console.WriteLine("6 - Unze (oz)");

        Console.Write("Quell-Einheit wählen (1-6): ");
        string fromChoice = Console.ReadLine();

        Console.Write("Ziel-Einheit wählen (1-6): ");
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

        double kg = ConvertToKg(value, fromChoice);
        double result = ConvertFromKg(kg, toChoice);

        string fromUnit = GetUnitName(fromChoice);
        string toUnit = GetUnitName(toChoice);

        Console.WriteLine($"{value} {fromUnit} = {result:F4} {toUnit}");
    }

    private bool IsValidChoice(string choice) => int.TryParse(choice, out int n) && n >= 1 && n <= 6;

    private double ConvertToKg(double v, string from) => from switch
    {
        "1" => v / 1_000_000,
        "2" => v / 1000,
        "3" => v,
        "4" => v * 1000,
        "5" => v / 2.20462,
        "6" => v / 35.274,
        _ => throw new ArgumentException()
    };

    private double ConvertFromKg(double kg, string to) => to switch
    {
        "1" => kg * 1_000_000,
        "2" => kg * 1000,
        "3" => kg,
        "4" => kg / 1000,
        "5" => kg * 2.20462,
        "6" => kg * 35.274,
        _ => throw new ArgumentException()
    };

    private string GetUnitName(string c) => c switch
    {
        "1" => "mg",
        "2" => "g",
        "3" => "kg",
        "4" => "t",
        "5" => "lbs",
        "6" => "oz",
        _ => "?"
    };
}
using System;

public class TemperatureConverter : IConverter
{
    public void Convert()
    {
        Console.WriteLine("Verfügbare Einheiten:");
        Console.WriteLine("1 - Celsius (°C)");
        Console.WriteLine("2 - Fahrenheit (°F)");
        Console.WriteLine("3 - Kelvin (K)");

        Console.Write("Quell-Einheit wählen (1-3): ");
        string fromChoice = Console.ReadLine();

        Console.Write("Ziel-Einheit wählen (1-3): ");
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

        double celsius = ConvertToCelsius(value, fromChoice);
        double result = ConvertFromCelsius(celsius, toChoice);

        string fromUnit = GetUnitName(fromChoice);
        string toUnit = GetUnitName(toChoice);

        Console.WriteLine($"{value} {fromUnit} = {result:F2} {toUnit}");
    }

    private bool IsValidChoice(string choice) => choice is "1" or "2" or "3";

    private double ConvertToCelsius(double value, string fromChoice) => fromChoice switch
    {
        "1" => value,
        "2" => (value - 32) * 5 / 9,
        "3" => value - 273.15,
        _ => throw new ArgumentException()
    };

    private double ConvertFromCelsius(double c, string toChoice) => toChoice switch
    {
        "1" => c,
        "2" => (c * 9 / 5) + 32,
        "3" => c + 273.15,
        _ => throw new ArgumentException()
    };

    private string GetUnitName(string choice) => choice switch
    {
        "1" => "°C",
        "2" => "°F",
        "3" => "K",
        _ => "?"
    };
}

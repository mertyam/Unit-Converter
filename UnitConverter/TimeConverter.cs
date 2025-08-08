using System;

public class TimeConverter : IConverter
{
    public void Convert()
    {
        Console.WriteLine("Verfügbare Einheiten:");
        Console.WriteLine("1 - Sekunden (s)");
        Console.WriteLine("2 - Minuten (min)");
        Console.WriteLine("3 - Stunden (h)");
        Console.WriteLine("4 - Tage (d)");

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

        double seconds = ConvertToSeconds(value, fromChoice);
        double result = ConvertFromSeconds(seconds, toChoice);

        string fromUnit = GetUnitName(fromChoice);
        string toUnit = GetUnitName(toChoice);

        Console.WriteLine($"{value} {fromUnit} = {result:F4} {toUnit}");
    }

    private bool IsValidChoice(string c) => int.TryParse(c, out int n) && n >= 1 && n <= 4;

    private double ConvertToSeconds(double v, string f) => f switch
    {
        "1" => v,
        "2" => v * 60,
        "3" => v * 3600,
        "4" => v * 86400,
        _ => throw new ArgumentException()
    };

    private double ConvertFromSeconds(double s, string t) => t switch
    {
        "1" => s,
        "2" => s / 60,
        "3" => s / 3600,
        "4" => s / 86400,
        _ => throw new ArgumentException()
    };

    private string GetUnitName(string c) => c switch
    {
        "1" => "s",
        "2" => "min",
        "3" => "h",
        "4" => "d",
        _ => "?"
    };
}

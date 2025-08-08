using System;
using System.ComponentModel;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Unit Converter ===");

        while (true)
        {
            Console.WriteLine("\nWas willst du umrechnen?");
            Console.WriteLine("1 - Länge");
            Console.WriteLine("2 - Temperatur");
            Console.WriteLine("3 - Gewicht");
            Console.WriteLine("4 - Volumen");
            Console.WriteLine("5 - Fläche");
            Console.WriteLine("6 - Geschwindigkeit");
            Console.WriteLine("7 - Zeit");
            Console.WriteLine("0 - Beenden");

            Console.Write("Auswahl: ");
            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            IConverter converter = choice switch
            {
                "1" => new LengthConverter(),
                "2" => new TemperatureConverter(),
                "3" => new WeightConverter(),
                "4" => new VolumeConverter(),
                "5" => new AreaConverter(),
                "6" => new SpeedConverter(),
                "7" => new TimeConverter(),
                _ => null
            };

            if (converter != null)
            {
                converter.Convert();
            }
            else
            {
                Console.WriteLine("Ungültige Auswahl.");
            }
        }

        Console.WriteLine("Programm beendet.");
    }
}

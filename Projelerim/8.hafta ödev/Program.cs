using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> values = new List<double>();
        Console.WriteLine("RECURSİVE İLE STANDART SAPMA HESAPLAMA");
        Console.WriteLine("");
        Console.Write("Kaç değer gireceksiniz? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Değer girin: ");
            double value = double.Parse(Console.ReadLine());
            values.Add(value);
        }

        double mean = CalculateMean(values, values.Count);
        double variance = CalculateVariance(values, mean, values.Count);
        double standardDeviation = Math.Sqrt(variance);

        Console.WriteLine($"Standart Sapma: {standardDeviation}");
        Console.ReadKey();
    }

    static double CalculateMean(List<double> values, int count)
    {
        if (count == 1)
            return values[0];
        else
            return ((CalculateMean(values, count - 1) * (count - 1) + values[count - 1]) / count);
    }

    static double CalculateVariance(List<double> values, double mean, int count)
    {
        if (count == 1)
            return Math.Pow(values[0] - mean, 2);
        else
            return ((CalculateVariance(values, mean, count - 1) * (count - 1) + Math.Pow(values[count - 1] - mean, 2)) / count);
    }
}

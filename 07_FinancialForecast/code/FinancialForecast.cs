using System;

public class Forecasting
{
    public static double PredictFutureValue(double currentValue, double growthRate, int years)
    {
        if (years == 0)
            return currentValue;
        return PredictFutureValue(currentValue * (1 + growthRate), growthRate, years - 1);
    }

    public static double PredictFutureValueIterative(double currentValue, double growthRate, int years)
    {
        for (int i = 0; i < years; i++)
        {
            currentValue *= (1 + growthRate);
        }
        return currentValue;
    }
}

public class Program
{
    public static void Main()
    {
        double currentValue = 10000; 
        double growthRate = 0.08;    
        int years = 5;

        double futureValueRecursive = Forecasting.PredictFutureValue(currentValue, growthRate, years);
        Console.WriteLine($"[Recursive] Future Value after {years} years: ₹{futureValueRecursive:F2}");

        double futureValueIterative = Forecasting.PredictFutureValueIterative(currentValue, growthRate, years);
        Console.WriteLine($"[Iterative] Future Value after {years} years: ₹{futureValueIterative:F2}");
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

class StatisticsAssignment
{
    static void Main(string[] args)
    {
        Console.WriteLine("=======================================================");
        Console.WriteLine("   Probability & Statistical Distributions Assignment  ");
        Console.WriteLine("   Student: Moaz Ezzat Abbas                          ");
        Console.WriteLine("=======================================================\n");

        // -------------------------------------------------------
        // TASK 1: Statistical Computations
        // -------------------------------------------------------
        double[] data = {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179,
            83, 21, 20, 21, 186, 177, 195, 193, 188, 199,
            62, 109, 105, 183, 110
        };

        Console.WriteLine("Input Data:");
        Console.WriteLine(string.Join(", ", data));
        Console.WriteLine($"n = {data.Length}\n");

        double[] sorted = data.OrderBy(x => x).ToArray();

        Console.WriteLine("Sorted Data:");
        Console.WriteLine(string.Join(", ", sorted));
        Console.WriteLine();

        // (i) Mean
        double mean = ComputeMean(data);
        Console.WriteLine($"(i)   Mean                 = {mean:F4}");

        // (ii) Mode
        var modes = ComputeMode(data);
        Console.WriteLine($"(ii)  Mode                 = {string.Join(", ", modes)}");

        // (iii) Median
        double median = ComputePercentile(sorted, 50);
        Console.WriteLine($"(iii) Median               = {median:F4}");

        // (iv) Variance (population variance)
        double variance = ComputeVariance(data, mean);
        Console.WriteLine($"(iv)  Variance             = {variance:F4}");

        // (v) P20
        double p20 = ComputePercentile(sorted, 20);
        Console.WriteLine($"(v)   P20                  = {p20:F4}");

        // (vi) P50
        double p50 = ComputePercentile(sorted, 50);
        Console.WriteLine($"(vi)  P50                  = {p50:F4}");

        // (vii) Third quartile (Q3 = P75)
        double q3 = ComputePercentile(sorted, 75);
        Console.WriteLine($"(vii) Third Quartile (Q3)  = {q3:F4}");

        // (viii) Second Quartile (Q2 = Median = P50)
        double q2 = ComputePercentile(sorted, 50);
        Console.WriteLine($"(viii)Second Quartile (Q2) = {q2:F4}");

        // (ix) Third Quartile (Q3) — same as (vii)
        Console.WriteLine($"(ix)  Third Quartile (Q3)  = {q3:F4}");

        // (x) Range
        double range = ComputeRange(data);
        Console.WriteLine($"(x)   Range                = {range:F4}");

        // (xi) Interquartile Range (IQR)
        double q1 = ComputePercentile(sorted, 25);
        double iqr = q3 - q1;
        Console.WriteLine($"(xi)  Interquartile Range  = {iqr:F4}  (Q1={q1:F4}, Q3={q3:F4})");

        // (xii) Standard Deviation
        double stdDev = Math.Sqrt(variance);
        Console.WriteLine($"(xii) Standard Deviation   = {stdDev:F4}");

        // (xiii) Summation of Divisions (sum of each value divided by mean)
        double sumOfDivisions = ComputeSumOfDivisions(data, mean);
        Console.WriteLine($"(xiii)Summation of Div.    = {sumOfDivisions:F4}  (Σ xi/mean)");

        // -------------------------------------------------------
        // TASK 2: Outlier Detection using IQR method
        // -------------------------------------------------------
        Console.WriteLine("\n=======================================================");
        Console.WriteLine("   TASK 2: Outlier Detection (IQR Method)             ");
        Console.WriteLine("=======================================================\n");

        double lowerFence = q1 - 1.5 * iqr;
        double upperFence = q3 + 1.5 * iqr;

        Console.WriteLine($"Q1 = {q1:F4}");
        Console.WriteLine($"Q3 = {q3:F4}");
        Console.WriteLine($"IQR = {iqr:F4}");
        Console.WriteLine($"Lower Fence (Q1 - 1.5*IQR) = {lowerFence:F4}");
        Console.WriteLine($"Upper Fence (Q3 + 1.5*IQR) = {upperFence:F4}");
        Console.WriteLine();

        Console.WriteLine("{0,-12} {1}", "Value", "Status");
        Console.WriteLine(new string('-', 30));

        foreach (double val in data)
        {
            bool isOutlier = val < lowerFence || val > upperFence;
            string status = isOutlier ? "*** OUTLIER ***" : "Normal";
            Console.WriteLine($"{val,-12} {status}");
        }

        Console.WriteLine("\n=======================================================");
        Console.WriteLine("   End of Assignment");
        Console.WriteLine("=======================================================");
    }

    // ---- Helper Methods ----

    static double ComputeMean(double[] data)
    {
        return data.Sum() / data.Length;
    }

    static List<double> ComputeMode(double[] data)
    {
        var freq = data.GroupBy(x => x)
                       .ToDictionary(g => g.Key, g => g.Count());
        int maxFreq = freq.Values.Max();

        // If all elements appear equally, there's no mode
        if (maxFreq == 1)
            return new List<double> { double.NaN };

        return freq.Where(kv => kv.Value == maxFreq)
                   .Select(kv => kv.Key)
                   .OrderBy(x => x)
                   .ToList();
    }

    static double ComputePercentile(double[] sortedData, double percentile)
    {
        // Using the inclusive method (linear interpolation)
        int n = sortedData.Length;
        double rank = (percentile / 100.0) * (n - 1);
        int lower = (int)Math.Floor(rank);
        int upper = (int)Math.Ceiling(rank);

        if (lower == upper)
            return sortedData[lower];

        double fraction = rank - lower;
        return sortedData[lower] + fraction * (sortedData[upper] - sortedData[lower]);
    }

    static double ComputeVariance(double[] data, double mean)
    {
        // Population variance
        return data.Sum(x => Math.Pow(x - mean, 2)) / data.Length;
    }

    static double ComputeRange(double[] data)
    {
        return data.Max() - data.Min();
    }

    static double ComputeSumOfDivisions(double[] data, double mean)
    {
        // Σ (xi / mean)
        return data.Sum(x => x / mean);
    }
}

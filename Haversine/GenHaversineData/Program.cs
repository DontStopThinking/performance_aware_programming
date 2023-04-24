// See https://aka.ms/new-console-template for more information

// THIS IS TOO SLOW!!!

/*using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

const int num = 10000000;
/*try
{
    num = int.Parse(args[0]);
}
catch (IndexOutOfRangeException)
{
    Console.Error.WriteLine("Error: Please provide the number of pairs you want to generate.");
}#1#

const double minX = -90.0;
const double maxX = 90.0;
const double minY = -180.0;
const double maxY = 180.0;

Random random = new();

long startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

List<Pair> pairs = new(num);
for (int i = 0; i < num; i++)
{
    Pair pair = new()
    {
        X0 = RandomDouble(minX, maxX),
        X1 = RandomDouble(minX, maxX),
        Y0 = RandomDouble(minY, maxY),
        Y1 = RandomDouble(minY, maxY)
    };
    pairs.Add(pair);
}

long midTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

JsonSerializerOptions options = new()
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

string outputFileName = $"data_{num}_flex.json";
string outputFilePath = Path.Combine("..", "..", "..", "..", "data", outputFileName);
string json = JsonSerializer.Serialize(new { pairs }, options);
File.WriteAllText(outputFilePath, json);

long endTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

// Print result
Console.WriteLine($"Generated {outputFileName} in {endTime - startTime} seconds");
Console.WriteLine($"Generating list: {midTime - startTime} seconds");
Console.WriteLine($"Writing file: {endTime - midTime} seconds");

double RandomDouble(double min, double max)
{
    return random.NextDouble() * (max - min) + min;
}

internal class Pair
{
    public double X0 { get; set; }
    public double Y0 { get; set; }
    public double X1 { get; set; }
    public double Y1 { get; set; }
}*/

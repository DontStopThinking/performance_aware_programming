// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

long startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

// Read the json
const int num = 10000000;
string jsonFilePath = Path.Combine("..", "..", "..", "..", "data", $"data_{num}_flex.json");

PairsJson? jsonInput;
try
{
    string jsonFile = File.ReadAllText(jsonFilePath);
    jsonInput = JsonSerializer.Deserialize<PairsJson>(jsonFile);
}
catch (Exception ex)
{
    Console.WriteLine($"Error reading JSON: {ex.Message}");
    return;
}

if (jsonInput?.Pairs is null)
{
    Console.Error.WriteLine("ERROR: Failed to read json file.");
    return;
}

long midTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

const int earthRadiusKm = 6371;
double sum = 0;
int count = 0;

// Average the Haversine
foreach (Pair pair in jsonInput.Pairs)
{
    sum += HaversineOfDegrees(pair.X0, pair.Y0, pair.X1, pair.Y1, earthRadiusKm);
    count++;
}

double average = sum / count;

long endTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

// Display the result
Console.WriteLine($"Result: {average}");
Console.WriteLine($"Input: {midTime - startTime} seconds");
Console.WriteLine($"Math: {endTime - midTime} seconds");
Console.WriteLine($"Total: {endTime - startTime} seconds");
Console.WriteLine($"Throughput: {count / (endTime - midTime)} haversines/seconds");

/********************************************************************/

double HaversineOfDegrees(double x0, double y0, double x1, double y1, int r)
{
    double dY = ToRadians(y1 - y0);
    double dX = ToRadians(x1 - x0);
    y0 = ToRadians(y0);
    y1 = ToRadians(y1);

    double rootTerm = Math.Pow(Math.Sin(dY / 2), 2) + Math.Cos(y0) * Math.Cos(y1) * Math.Pow(Math.Sin(dX / 2), 2);
    double result = 2 * r * Math.Asin(Math.Sqrt(rootTerm));

    return result;
}

double ToRadians(double degrees)
{
    return degrees * Math.PI / 180;
}

internal class PairsJson
{
    [JsonPropertyName("pairs")]
    public List<Pair>? Pairs { get; set; }
}

internal class Pair
{
    [JsonPropertyName("x0")]
    public double X0 { get; set; }

    [JsonPropertyName("y0")]
    public double Y0 { get; set; }

    [JsonPropertyName("x1")]
    public double X1 { get; set; }

    [JsonPropertyName("y1")]
    public double Y1 { get; set; }
}

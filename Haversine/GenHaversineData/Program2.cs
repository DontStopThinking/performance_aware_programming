using System;
using System.IO;
using System.Text;

const int num = 10;

const double minX = -90.0;
const double maxX = 90.0;
const double minY = -180.0;
const double maxY = 180.0;

Random random = new();

StringBuilder sb = new(num + 4);

long startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

sb.Append($"{{{Environment.NewLine}  \"pairs\": [{Environment.NewLine}");
for (int i = 1; i != num; i++)
{
    Pair pair = new()
    {
        X0 = Math.Round(RandomDouble(minX, maxX), 6),
        Y0 = Math.Round(RandomDouble(minY, maxY), 6),
        X1 = Math.Round(RandomDouble(minX, maxX), 6),
        Y1 = Math.Round(RandomDouble(minY, maxY), 6)
    };
    sb.Append($"    {{ \"x0\": {pair.X0}, \"y0\": {pair.Y0}, \"x1\": {pair.X1}, \"y1\": {pair.Y1} }}");

    if (i != num - 1)
    {
        sb.Append(',');
    }

    if (i < num)
    {
        sb.Append($"{Environment.NewLine}");
    }
}

sb.Append($"  ] {Environment.NewLine}}}{Environment.NewLine}");

long midTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

string outputFileName = $"data_{num}_flex.json";
string outputFilePath = Path.Combine("..", "..", "..", "..", "data", outputFileName);
File.WriteAllText(outputFilePath, sb.ToString());

long endTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

// Display the result
Console.WriteLine($"Generated {outputFileName} in {endTime - startTime} seconds.");
Console.WriteLine($"Generating string: {midTime - startTime} seconds.");
Console.WriteLine($"Writing file: {endTime - midTime} seconds.");

/********************************************************************/

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
}

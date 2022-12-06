using System.Text.RegularExpressions;
public class Day06
{
    public Day06()
    {
        Console.WriteLine("Day 6:");
        string[] lines = File.ReadAllLines(@"input\Day06.txt");

        int startPosition = GetStartMarker(lines[0], 4);
        int messagePosition = GetStartMarker(lines[0], 14);

        Console.WriteLine($"Start Marker: {startPosition}");
        Console.WriteLine($"Message Marker: {messagePosition}");
    }


    private int GetStartMarker(string line, int length)
    {
        for (int i = length; i < line.Length; i++)
            if (line.Substring(i - length, length).Distinct().Count() == length)
                return i;

        return 0;
    }
}
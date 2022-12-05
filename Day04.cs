using System.Text.RegularExpressions;
public class Day04
{
    public Day04()
    {
        Console.WriteLine("Day 4:");
        //string[] lines = File.ReadAllLines(@"input\exampleDay04.txt");
        string[] lines = File.ReadAllLines(@"input\Day04.txt");

        int contained = 0;
        int partially = 0;
        foreach (string line in lines)
        {
            (List<int> e1List, List<int> e2List) pair = FillPair(line);
            if (IsPairFullyContained(pair))
                contained++;
            if (IsPairPartiallyOverlapped(pair))
                partially++;
        }


        Console.WriteLine($"Fully Contained: {contained}");
        Console.WriteLine($"Partially Overlapped: {partially}");
    }

    private bool IsPairPartiallyOverlapped((List<int> e1List, List<int> e2List) pair)
    {
        bool e1inE2 = false;
        bool e2inE1 = false;

        foreach (int e1 in pair.e1List) // For each element
        {
            if (pair.e2List.Any(x => x == e1)) // Element is in List
            {
                e1inE2 = true; 
                break;
            }
        }

        foreach (int e2 in pair.e2List)
        {
            if (pair.e1List.Any(x => x == e2))
            {
                e2inE1 = true;
                break;
            }
        }

        return e1inE2 || e2inE1;
    }

    private bool IsPairFullyContained((List<int> e1List, List<int> e2List) pair)
    {
        bool e1inE2 = true;
        bool e2inE1 = true;

        foreach (int e1 in pair.e1List) // For each element
        {
            if (pair.e2List.Any(x => x == e1)) // Element is in List
                continue;

            e1inE2 = false; // Element not in List
            break;
        }

        foreach (int e2 in pair.e2List)
        {
            if (pair.e1List.Any(x => x == e2))
                continue;

            e2inE1 = false;
            break;
        }

        return e1inE2 || e2inE1;
    }

    private (List<int> e1List, List<int> e2List) FillPair(string line)
    {
        Regex rx = new Regex(@"\d+");
        MatchCollection matches = rx.Matches(line);

        List<int> e1List = new();
        List<int> e2List = new();

        int fromE1 = 0;
        int toE1 = 0;
        int fromE2 = 0;
        int toE2 = 0;

        Int32.TryParse(matches[0].Value, out fromE1);
        Int32.TryParse(matches[1].Value, out toE1);
        Int32.TryParse(matches[2].Value, out fromE2);
        Int32.TryParse(matches[3].Value, out toE2);

        for (int e1 = fromE1; e1 <= toE1; e1++)
            e1List.Add(e1);

        for (int e2 = fromE2; e2 <= toE2; e2++)
            e2List.Add(e2);

        return (e1List, e2List);
    }
}
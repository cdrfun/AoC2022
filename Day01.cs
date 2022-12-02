
public class Day01
{
    public Day01()
    {
        Console.WriteLine("Day 1:");
        string[] lines = File.ReadAllLines(@"input\day1.txt");
        List<int> elves = new();
        elves.Add(0);

        foreach(string line in lines)
        {
            if(String.IsNullOrEmpty(line))
            {
                elves.Add(0);
            }
            else
            {
                int calories;

                Int32.TryParse(line, out calories);
                elves[^1] +=calories;
            }
        }

        Console.WriteLine($"Most calorie elf: {elves.Max()}");
        Console.WriteLine($"Calories top 3 elves: {elves.OrderByDescending(x => x).Take(3).Sum()}");
    }
}
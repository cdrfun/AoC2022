using System.Text.RegularExpressions;
public class Day05
{
    public Day05()
    {
        Console.WriteLine("Day 5:");
        //string[] lines = File.ReadAllLines(@"input\exampleDay05.txt");
        string[] lines = File.ReadAllLines(@"input\Day05.txt");

        Stack<char>[] stacks = ReadStacks(lines);
        Stack<char>[] stacks2 = ReadStacks(lines);
        stacks = ProcessCommands(stacks, lines);
        stacks2 = ProcessCommands9001(stacks2, lines);


        Console.WriteLine($"Arrangement: {GetTopItems(stacks)}");
        Console.WriteLine($"Arrangement 9001: {GetTopItems(stacks2)}");
    }

    private string GetTopItems(Stack<char>[] stacks)
    {
        string result = "";
        foreach (Stack<char> stack in stacks)
        {
            result += stack.Pop();
        }
        return result;
    }
    private Stack<char>[] ProcessCommands9001(Stack<char>[] stacks, string[] lines)
    {
        Regex rx = new Regex(@"\d+");

        bool begin = false;
        foreach (string line in lines)
        {
            if (!begin)
            {
                if (String.IsNullOrEmpty(line))
                    begin = true;
                continue;
            }
            MatchCollection matches = rx.Matches(line);

            int count = 0;
            int from = 0;
            int to = 0;
            Int32.TryParse(matches[0].Value, out count);
            Int32.TryParse(matches[1].Value, out from);
            Int32.TryParse(matches[2].Value, out to);

            from--;
            to--;

            List<char> substack = stacks[from].Take(count).ToList();

            for (int s = 0; s < count; s++)
            {
                stacks[to].Push(substack.Last());
                substack.RemoveAt(substack.Count - 1);
                stacks[from].Pop();
            }
        }

        return stacks;
    }

    private Stack<char>[] ProcessCommands(Stack<char>[] stacks, string[] lines)
    {
        Regex rx = new Regex(@"\d+");

        bool begin = false;
        foreach (string line in lines)
        {
            if (!begin)
            {
                if (String.IsNullOrEmpty(line))
                    begin = true;
                continue;
            }
            MatchCollection matches = rx.Matches(line);

            int count = 0;
            int from = 0;
            int to = 0;
            Int32.TryParse(matches[0].Value, out count);
            Int32.TryParse(matches[1].Value, out from);
            Int32.TryParse(matches[2].Value, out to);

            from--;
            to--;

            for (int s = 0; s < count; s++)
                stacks[to].Push(stacks[from].Pop());
        }

        return stacks;
    }

    private Stack<char>[] ReadStacks(string[] lines)
    {
        string countLine = "";
        foreach (string line in lines)
        {
            if (String.IsNullOrEmpty(line))
                break;
            countLine = line;
        }

        int stackCount = GetMaxNumber(countLine);
        Stack<char>[] result = new Stack<char>[stackCount];
        int[] stackPositions = GetStackPositions(stackCount);

        for (int l = 0; l < lines.Length - 1; l++)
        {
            string line = lines[l];

            if (String.IsNullOrEmpty(lines[l + 1]))
                break;

            for (int i = 0; i < stackPositions.Length; i++)
            {
                if (result[i] is null)
                    result[i] = new();

                if (line[stackPositions[i]] != ' ')
                    result[i].Push(line[stackPositions[i]]);
            }
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new Stack<char>(result[i].ToArray()); // Effectivley reverses Stack
        }




        return result;
    }

    private int GetMaxNumber(string line)
    {
        if (line is null)
        {
            throw new ArgumentNullException(nameof(line));
        }

        int result = 0;
        foreach (char c in line)
        {
            int current = 0;
            if (c != ' ')
                Int32.TryParse(c.ToString(), out current);

            if (current > result)
                result = current;
        }

        return result;
    }

    private int[] GetStackPositions(int stackCount)
    {
        int[] stackPositions = new int[stackCount];
        const int firstPosition = 1;
        const int spaceBetweenPositions = 4;

        for (int i = 0; i < stackPositions.Length; i++)
        {
            if (i == 0)
                stackPositions[i] = firstPosition;
            else
                stackPositions[i] = stackPositions[i - 1] + spaceBetweenPositions;
        }

        return stackPositions;
    }
}
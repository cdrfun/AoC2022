
public class Day02
{
    private string[] lines;

    private const int draw = 3;
    private const int won = 6;
    private const int lost = 0;

    private const int scoreX = 1;
    private const int scoreY = 2;
    private const int scoreZ = 3;

    public Day02()
    {
        Console.WriteLine("Day 2:");
        lines = File.ReadAllLines(@"input\day2.txt");

        Console.WriteLine($"Score Variant 1: {calculateScore1()}");        
        Console.WriteLine($"Score Variant 2: {calculateScore2()}");        
    }

    private int calculateScore2()
    {
        int result = 0;
        foreach (string line in lines)
        {
            string opponent = line[0].ToString();
            string me = line[^1].ToString(); ;
            result += chooseHand(me, opponent);
        }

        return result;
    }

    private int calculateScore1()
    {
        int result = 0;
        foreach (string line in lines)
        {
            string opponent = line[0].ToString();
            string me = line[^1].ToString(); ;
            result += getScore(me, opponent);
        }

        return result;
    }

    private int chooseHand(string me, string opponent)
    {
        /*
        X LOSE
        Y DRAW
        Z WIN

        In
        A Rock
        B Paper
        C Scrissors

        Out
        X Rock
        Y Paper
        Z Scrissors
        */
        string meChosen = "";
        switch(opponent)
        {
            case "A":
                switch(me)
                {
                    case "X":
                        meChosen = "Z";
                        break;
                    case "Y":
                        meChosen = "X";
                        break;
                    case "Z":
                        meChosen = "Y";
                        break;
                }
                break;
            case "B":
                switch(me)
                {
                    case "X":
                        meChosen = "X";
                        break;
                    case "Y":
                        meChosen = "Y";
                        break;
                    case "Z":
                        meChosen = "Z";
                        break;
                }
                break;
            case "C":
                            switch(me)
                {
                    case "X":
                        meChosen = "Y";
                        break;
                    case "Y":
                        meChosen = "Z";
                        break;
                    case "Z":
                        meChosen = "X";
                        break;
                }
                break;
        }

        return getScore(meChosen, opponent);
    }

    private int getScore(string me, string opponent)
    {
        int result = 0;
        switch (me)
        {
            case "X":
                result += scoreX;
                switch (opponent)
                {
                    case "A":
                        result += draw;
                        break;
                    case "B":
                        result += lost;
                        break;
                    case "C":
                        result += won;
                        break;
                }
                break;
            case "Y":
                result += scoreY;
                switch (opponent)
                {
                    case "A":
                        result += won;
                        break;
                    case "B":
                        result += draw;
                        break;
                    case "C":
                        result += lost;
                        break;
                }
                break;
            case "Z":
                result += scoreZ;
                switch (opponent)
                {
                    case "A":
                        result += lost;
                        break;
                    case "B":
                        result += won;
                        break;
                    case "C":
                        result += draw;
                        break;
                }
                break;


        }
        return result;
    }
}
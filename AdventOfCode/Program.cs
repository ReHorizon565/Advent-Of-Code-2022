namespace AdventOfCode
{
    internal class Program
    {
        static int TopThreeMaxCallories(string callories)
        {
            return callories
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(x => x.Split(Environment.NewLine).Select(x => int.Parse(x)).Sum())
                .OrderDescending().Take(3).Sum();
        }
        static int MaxCallories(string callories)
        {
            return callories
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(x => x.Split(Environment.NewLine).Select(x => int.Parse(x)).Sum())
                .Max();
        }
        static int RockPaperScissorsTotal2(string strategy)
        {
            Dictionary<char, char> wins = new Dictionary<char, char>()
            {
                { 'A', 'C' },
                { 'B', 'A' },
                { 'C' , 'B' }
            };
            Dictionary<char, char> loses = new Dictionary<char, char>()
            {
                { 'A', 'B' },
                { 'B', 'C' },
                { 'C' , 'A' }
            };
            Dictionary<char, int> scores = new Dictionary<char, int>()
            {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 }
            };
            return strategy
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    int score = 0;
                    // We must lose
                    if (x.Last() == 'X')
                        score += scores[wins[x.First()]];
                    // Draw
                    else if (x.Last() == 'Y')
                        score += scores[x.First()] + 3;
                    // Win
                    else
                        score += scores[loses[x.First()]] + 6;

                    return score;
                })
                .Sum();
        }
        static int RockPaperScissorsTotal(string strategy)
        {
            Dictionary<char, char> draws = new Dictionary<char, char>() {
                { 'A', 'X' },
                { 'B', 'Y' },
                { 'C', 'Z' }
            };
            Dictionary<char, char> wins = new Dictionary<char, char>()
            {
                { 'X', 'C' },
                { 'Y', 'A' },
                { 'Z' , 'B' }
            };
            return strategy
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    int score = 0;
                    // Draw
                    if (x.Last() == draws[x.First()])
                        score += 3;
                    // Win
                    else if (x.First() == wins[x.Last()])
                        score += 6;

                    if (x.Last() == 'X')
                        score += 1;
                    else if (x.Last() == 'Y')
                        score += 2;
                    else
                        score += 3;

                    return score;
                })
                .Sum();
        }
        static int RucksackSum(string rucksacks)
        {
            return rucksacks
                .Split(Environment.NewLine)
                .Select(x =>
                {
                    string common = "";
                    string firstHalf = x.Substring(0, x.Length / 2);
                    string secondHalf = x.Substring(x.Length / 2);
                    foreach (char c in firstHalf)
                    {
                        if (secondHalf.Contains(c) && !common.Contains(c))
                            common += c;
                    }
                    return common;
                })
                .Select(x =>
                {
                    int priority = 0;
                    foreach (char c in x)
                    {
                        int code = c;
                        // Lowercase
                        if (code >= 97 && code <= 122)
                            priority += code - 96;
                        // Uppercase
                        if (code >= 65 && code <= 90)
                            priority += code - 38;
                    }
                    return priority;
                })
                .Sum();
        }
        static int RucksackSum2(string rucksacks)
        {
            string capitalAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return rucksacks
                .Split(Environment.NewLine)
                .Select((value, index) => new { index, value })
                .GroupBy(x => x.index / 3, x => x.value)
                .Select(x =>
                {
                    string common = capitalAlphabet + capitalAlphabet.ToLower();
                    foreach (var rucksack in x)
                        common = string.Join("", common.Intersect(rucksack));
                    return common;
                })
                .Select(x =>
                {
                    int priority = 0;
                    foreach (char c in x)
                    {
                        int code = c;
                        // Lowercase
                        if (code >= 97 && code <= 122)
                            priority += code - 96;
                        // Uppercase
                        if (code >= 65 && code <= 90)
                            priority += code - 38;
                    }
                    return priority;
                })
                .Sum();
        }
        static void Main(string[] args)
        {
            // #1
            Console.WriteLine("#1");
            string callories = File.ReadAllText("1.txt");
            Console.WriteLine("Max callories: " + MaxCallories(callories));
            Console.WriteLine("Top Three Max Callories: " + TopThreeMaxCallories(callories) + "\n");

            // #2
            Console.WriteLine("#2");
            string strategy = File.ReadAllText("2.txt");
            Console.WriteLine("Total Points from strategy: " + RockPaperScissorsTotal(strategy));
            Console.WriteLine("Total Points from strategy (part 2): " + RockPaperScissorsTotal2(strategy) + "\n");

            // #3
            Console.WriteLine("#3");
            string rucksacks = File.ReadAllText("3.txt");
            Console.WriteLine("Rucksacks Total Item Priority: " + RucksackSum(rucksacks));
            Console.WriteLine("Rucksacks Total Item Priority (part 2): " + RucksackSum2(rucksacks));
        }
    }
}
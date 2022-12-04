namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1
            Console.WriteLine("#1");
            string callories = File.ReadAllText("1.txt");
            Console.WriteLine("Max callories: " + Day1.MaxCallories(callories));
            Console.WriteLine("Top Three Max Callories: " + Day1.TopThreeMaxCallories(callories) + "\n");

            // #2
            Console.WriteLine("#2");
            string strategy = File.ReadAllText("2.txt");
            Console.WriteLine("Total Points from strategy: " + Day2.RockPaperScissorsTotal(strategy));
            Console.WriteLine("Total Points from strategy (part 2): " + Day2.RockPaperScissorsTotal2(strategy) + "\n");

            // #3
            Console.WriteLine("#3");
            string rucksacks = File.ReadAllText("3.txt");
            Console.WriteLine("Rucksacks Total Item Priority: " + Day3.RucksackSum(rucksacks));
            Console.WriteLine("Rucksacks Total Item Priority (part 2): " + Day3.RucksackSum2(rucksacks) + "\n");

            // #4
            Console.WriteLine("#4");
            string pairs = File.ReadAllText("4.txt");
            Console.WriteLine("Overlaping pairs: " + Day4.Overlaps(pairs));
            Console.WriteLine("Overlaping pairs (part 2): " + Day4.Overlaps2(pairs));
        }
    }
}
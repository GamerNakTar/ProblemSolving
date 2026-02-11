using ProblemSolving.Algorithms;

namespace ProblemSolving;

internal static class Program
{
    static void Main()
    {
        var input = Console.ReadLine();
        var groups = input.Split('-');
        var result = 0;

        for (var i = 0; i < groups.Length; i++)
        {
            var numbers = groups[i].Split('+');
            var currentSum = numbers.Sum(int.Parse);

            if (i == 0)
            {
                result += currentSum;
            }
            else
            {
                result -= currentSum;
            }
        }

        Console.WriteLine(result);
    }
}

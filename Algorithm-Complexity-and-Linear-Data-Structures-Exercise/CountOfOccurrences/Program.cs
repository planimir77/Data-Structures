using System;

namespace CountOfOccurrences
{
    public class Program
    {
        static void Main(string[] args)
        {
            var countOfOccurrences = new CountOfOccurrences();
            var input = Console.ReadLine();
            var result = countOfOccurrences.GetCount(input);
            Console.WriteLine(result);
        }
    }
}

using System;
using System.Linq;

namespace SumAndAverage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine()?.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var sum = sequence?.Sum();
            var average = sum == 0 ? 0 : (double)sum / sequence.Count;
            
            Console.WriteLine($"Sum={sum}; Average={average:F2}");
        }
    }
}

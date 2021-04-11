using System;

namespace RemoveOddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var removeOddOccurrences = new RemoveOddOccurrences();
            Console.WriteLine(removeOddOccurrences.GetEven(Console.ReadLine()));
        }
    }
}

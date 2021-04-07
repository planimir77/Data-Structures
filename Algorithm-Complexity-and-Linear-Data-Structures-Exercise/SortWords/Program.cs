using System;
using System.Linq;

namespace SortWords
{
    public class Program
    {
        static void Main(string[] args)
        {
            var orderedList = Console.ReadLine()?
                .Split()
                .OrderBy(x=> x).ToList();

            Console.WriteLine(String.Join(" ", orderedList));
        }
    }
}

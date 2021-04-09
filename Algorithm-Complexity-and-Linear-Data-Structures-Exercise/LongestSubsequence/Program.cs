using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubsequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            var longestSubsequence = new LongestSubsequence();

            var input = Console.ReadLine();

            Console.WriteLine(longestSubsequence.Get(input));
        }
    }
}

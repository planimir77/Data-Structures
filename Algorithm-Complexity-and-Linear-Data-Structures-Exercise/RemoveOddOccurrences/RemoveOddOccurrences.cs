using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveOddOccurrences
{
    public class RemoveOddOccurrences
    {
        public string GetEven(string input)
        {
            var sequence = input.Split().Select(int.Parse).ToList();

            for (int i = 0; i < sequence.Count(); i++)
            {
                if (sequence.Count(x => x == sequence[i]) % 2 != 0)
                {
                    var target = sequence[i];
                    sequence.RemoveAll(x => x == target);
                    i--;
                }
            }

            return String.Join(" ", sequence);
        }
    }
}

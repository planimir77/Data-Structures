using System;
using System.Collections.Generic;
using System.Linq;

namespace CountOfOccurrences
{
    public class CountOfOccurrences
    {
        public string GetCount(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return "";

            var sequence = input?
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            var result = new List<string>();
            var count = 0;

            for (int index = 0; index < sequence.Count(); index++)
            {
                var current = sequence[index];
                // if no next element set next to -1
                var next = (index == sequence.Count - 1) ? -1 : sequence[index + 1];
                count++;

                if (next != current)
                {
                    result.Add($"{current} -> {count} times");
                    count = 0;
                }
            }

            return String.Join(Environment.NewLine, result);
        }
    }
}

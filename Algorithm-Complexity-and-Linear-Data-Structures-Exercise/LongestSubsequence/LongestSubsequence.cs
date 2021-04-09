using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestSubsequence
{
    public class LongestSubsequence
    {
        public string Get(string input)
        {
            var sequence = input.Split().Select(int.Parse).ToList();

            var result = new List<int>();
            var currentList = new List<int>();

            for (int i = 0; i < sequence?.Count; i++)
            {
                var currentNumber = sequence[i];

                if (i == 0)
                {
                    result.Add(currentNumber);
                    currentList.Add(currentNumber);
                    continue;
                }

                var previousNumber = sequence[i - 1];

                if (currentNumber == previousNumber)
                {
                    currentList.Add(currentNumber);
                }
                else
                {

                    currentList.Clear();
                    currentList.Add(currentNumber);
                }

                if (currentList.Count > result.Count)
                {
                    result.Clear();
                    foreach (var number in currentList)
                    {
                        result.Add(number);
                    }
                }
            }

            return String.Join(" ", result);
        }
    }
}

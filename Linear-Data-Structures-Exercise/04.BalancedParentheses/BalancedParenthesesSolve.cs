namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var stack = new Stack<char>();
            foreach (var currentChar in parentheses)
            {
                if (currentChar == '(' || currentChar == '{' || currentChar == '[')
                {
                    stack.Push(currentChar);
                }
                else
                { 
                    var lastChar = stack.Count == 0 ? ' ': stack.Peek();

                    if (lastChar == '(' && currentChar == ')' || lastChar == '{' && currentChar == '}' || lastChar == '[' && currentChar == ']')
                    {
                        var temp = stack.Pop();
                    }
                    else
                    {
                        stack.Push(currentChar);
                    }
                }
            }
            return stack.Count == 0 ;
        }
    }
}

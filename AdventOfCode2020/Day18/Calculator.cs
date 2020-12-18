namespace AdventOfCode2020.Day18
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Calculator
    {
        public long Calculate(string expression)
        {
            var RPN = TokenizeExpression(expression);
            return ExecuteTokens(RPN);
        }

        protected List<string> TokenizeExpression(string expression)
        {
            List<string> tokens = new List<string>();
            Stack<string> stack = new Stack<string>();
            string temp;

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    var numString = new StringBuilder();
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        numString.Append(expression[i++]);
                    }
                    tokens.Add(numString.ToString());
                }
                if (i >= expression.Length) break;

                char ch = expression[i];
                if (ch == '(')
                {
                    stack.Push(ch.ToString());
                }
                else if (ch == ')')
                {
                    temp = stack.Pop();
                    while (temp != "(")
                    {
                        tokens.Add(temp);
                        temp = stack.Pop();
                    }
                }
                else if ("*+".Contains(ch))
                {
                    while (stack.Count > 0 && stack.Peek() != "(" && Prec(stack.Peek()) >= Prec(ch.ToString()))
                    {
                        tokens.Add(stack.Pop());
                    }
                    stack.Push(ch.ToString());
                }
            }
            while (stack.Count > 0)
            {
                tokens.Add(stack.Pop());
            }
            return tokens;
        }

        protected virtual int Prec(string op) => 0;

        protected long ExecuteTokens(List<string> tokens)
        {
            Stack<long> stack = new Stack<long>();

            foreach (string token in tokens)
            {
                if (long.TryParse(token, out var num))
                {
                    stack.Push(num);
                }
                else if (token == "+")
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (token == "*")
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
            }
            // Remaining item on stack contains result
            return stack.Count > 0 ? stack.Pop() : 0L;
        }
    }
}

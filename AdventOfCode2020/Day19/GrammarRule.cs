namespace AdventOfCode2020.Day19
{
    using System;
    using System.Collections.Generic;

    public class GrammarRule
    {
        public GrammarRule(string from, string to)
        {
            From = from;
            if (to.Contains("a"))
            { 
                Terminal = "a";
            }
            else if (to.Contains("b"))
            {
                Terminal = "b";
            }
            else
            {
                To = new List<string>(to.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            }
        }

        public string From { get; }

        public string Terminal { get; }

        public List<string> To { get; }

        public bool IsTerminal => To is null;

        public override string ToString()
        {
            var str = IsTerminal ? Terminal.ToString() : To[0];
            if (To.Count > 1)
            {
                str += " " + To[1];
            }
            return $"{From} => {str}";
        }
    }
}

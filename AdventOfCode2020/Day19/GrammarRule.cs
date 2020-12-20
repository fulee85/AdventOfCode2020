namespace AdventOfCode2020.Day19
{
    using System;
    using System.Collections.Generic;

    public class GrammarRule
    {
        public GrammarRule(string from)
        {
            From = from;
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

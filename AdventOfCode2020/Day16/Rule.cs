namespace AdventOfCode2020.Day16
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Rule
    {
        private readonly string ruleName;
        private readonly int from1;
        private readonly int to1; 
        private readonly int from2;
        private readonly int to2;

        public Rule(string input)
        {
            var regex = new Regex(@"(?<rule_name>\w+\s?\w+): (?<from1>\d+)-(?<to1>\d+) or (?<from2>\d+)-(?<to2>\d+)");

            foreach (Match match in regex.Matches(input))
            {
                ruleName = match.Groups["rule_name"].Value;
                from1 = int.Parse(match.Groups["from1"].Value);
                to1 = int.Parse(match.Groups["to1"].Value);
                from2 = int.Parse(match.Groups["from2"].Value);
                to2 = int.Parse(match.Groups["to2"].Value);
            }
        }

        public string RuleName => ruleName;

        public IEnumerable<int> GetValidNumbers()
        {
            for (int i = from1; i <= to1; i++)
            {
                yield return i;
            }
            for (int i = from2; i <= to2; i++)
            {
                yield return i;
            }
        }

        internal bool IsValid(int v)
        {
            return from1 <= v && v <= to1 || from2 <= v && v <= to2;
        }
    }
}

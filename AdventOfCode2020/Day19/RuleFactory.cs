namespace AdventOfCode2020.Day19
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class RuleFactory
    {
        public static IEnumerable<GrammarRule> CreateRules(string input)
        {
            var rules = new List<GrammarRule>();
            var parts = input.Split(':');
            var from = parts[0].Trim();
            var toParts = parts[1].Split('|');
            foreach (var to in toParts)
            {
                var rule = new GrammarRule(from, to);
                rules.Add(rule);
            }
            return rules;
        }
    }
}

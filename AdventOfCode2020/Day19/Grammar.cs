namespace AdventOfCode2020.Day19
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Grammar
    {
        private List<GrammarRule> rules = new ();
        private GrammarRule startRule;
        private HashSet<string> words;

        public void AddRule(GrammarRule rule)
        {
            if (rule.From == "0")
            {
                startRule = rule;
            }
            rules.Add(rule);
        }

        public bool IsPartOf(string s)
        {
            if (words is null)
            {
                words = CalculateWords(startRule.From);
            }
            s = s.Trim();
            return words.Contains(s);
        }

        private int ruleEightRecursionCount = 0;
        private int ruleElevenRecursionCount = 0;
        private int maxRecursionAllowed = 1;

        private HashSet<string> CalculateWords(string start)
        {
            IEnumerable<GrammarRule> possibleRules = null;
            possibleRules = rules.Where(r => r.From == start);
            
            var result = new HashSet<string>();
            foreach (var rule in possibleRules)
            {
                if (rule.IsTerminal)
                {
                    result.Add(rule.Terminal);
                }
                else if (rule.To.Count == 1)
                {
                    var to1 = CalculateWords(rule.To[0]);
                    result.UnionWith(to1);
                }
                else if (rule.To.Count == 2)
                {
                    var to1 = CalculateWords(rule.To[0]);
                    var to2 = CalculateWords(rule.To[1]);
                    result.UnionWith(Combine(to1,to2));
                }
                else if (rule.To.Count == 3)
                {
                    var to1 = CalculateWords(rule.To[0]);
                    var to2 = CalculateWords(rule.To[1]);
                    var to3 = CalculateWords(rule.To[2]);
                    result.UnionWith(Combine(to1, Combine(to2, to3)));
                }
            }
            return result;
        }

        private HashSet<string> Combine(HashSet<string> hashSet1, HashSet<string> hashSet2)
        {
            var combined = new HashSet<string>();
            foreach (var item1 in hashSet1)
            {
                foreach (var item2 in hashSet2)
                {
                    combined.Add(item1 + item2);
                }
            }
            return combined;
        }
    }
}

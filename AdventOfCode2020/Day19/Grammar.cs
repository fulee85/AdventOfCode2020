namespace AdventOfCode2020.Day19
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Grammar
    {
        private static Dictionary<string, Rule> rulesDict;

        public Grammar()
        {
            rulesDict = new Dictionary<string, Rule>();
        }

        public HashSet<string> GetReachableWordsFrom(string start)
        {
            return rulesDict[start].GetReachableWords();
        }

        internal void AddRules(IEnumerable<string> ruleDefs)
        {
            foreach (var ruleDef in ruleDefs)
            {
                var ruleParts = ruleDef.Split(':').Select(s => s.Trim()).ToArray();
                var newRule = new Rule(ruleParts[0], ruleParts[1]);
                rulesDict[ruleParts[0]] = newRule;
            }
            rulesDict.Values.ForEach(r => r.SetToRules());
        }

        private class Rule
        {
            private readonly string to;
            private List<List<Rule>> toRules = new List<List<Rule>>();
            private HashSet<string> possibleWords;

            public Rule(string from, string to)
            {
                From = from;
                this.to = to;
            }

            public string From { get; }

            public void SetToRules() 
            {
                if (to.Contains("a"))
                {
                    possibleWords = new HashSet<string> { "a" };
                    return;
                }
                if (to.Contains("b"))
                {
                    possibleWords = new HashSet<string> { "b" };
                    return;
                }
                foreach (var item in to.Split('|'))
                {
                    var subRules = new List<Rule>();
                    foreach (var ruleId in item.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    {
                        subRules.Add(rulesDict[ruleId]);
                    }
                    toRules.Add(subRules);
                }
            }

            public HashSet<string> GetReachableWords()
            {
                if (possibleWords is null)
                {
                    possibleWords = SetReachableWords();
                }
                return possibleWords;
            }

            private HashSet<string> SetReachableWords()
            {
                var result = new HashSet<string>();
                foreach (var item in toRules)
                {
                    var x = new HashSet<string>();
                    foreach (var item2 in item)
                    {
                        x = Combine(x, item2.GetReachableWords());
                    }
                    result.UnionWith(x);
                }
                return result;
            }

            private HashSet<string> Combine(HashSet<string> hashSet1, HashSet<string> hashSet2)
            {
                if (hashSet1.Count == 0)
                {
                    return hashSet2;
                }
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
}

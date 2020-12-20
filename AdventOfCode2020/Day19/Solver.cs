namespace AdventOfCode2020.Day19
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly List<string> rulesInput;
        private readonly List<string> wordsInput;

        public Solver(IEnumerable<string> input)
        {
            rulesInput = input.TakeWhile(s => !string.IsNullOrEmpty(s)).ToList();
            wordsInput = input.SkipWhile(s => !string.IsNullOrEmpty(s)).Skip(1).ToList();
        }

        public string GetFirstSolution()
        {
            Grammar grammar = CreateGrammar(rulesInput);
            return wordsInput.Count(w => grammar.GetReachableWordsFrom("0").Contains(w)).ToString();
        }

        public string GetSecondSolution()
        {
            Grammar grammar = CreateGrammar(rulesInput);
            var reachableWordsFrom0 = grammar.GetReachableWordsFrom("0");
            var foundWords = wordsInput.Where(w => reachableWordsFrom0.Contains(w)).ToList();
            var wordNotFounds = wordsInput.Where(w => !reachableWordsFrom0.Contains(w));
            var reachableWordsFrom42 = grammar.GetReachableWordsFrom("42");
            var reachableWordsFrom31 = grammar.GetReachableWordsFrom("31");
            
            foreach (var notFoundWord in wordNotFounds)
            {
                if (IsReachebleWithNewRules(notFoundWord, reachableWordsFrom42, reachableWordsFrom31))
                {
                    foundWords.Add(notFoundWord);
                }
            }
            return foundWords.Count.ToString();
        }

        // Old Rules:
        // 8: 42
        // 11: 42 31
        // New Rules:
        // 8: 42 | 42 8
        // 11: 42 31 | 42 11 31
        // Regexp which writes down the new rules: "reachableWordsFrom42{a}42{b}31{b}" a>=1, b>=1
        private bool IsReachebleWithNewRules(string notFoundWord, HashSet<string> reachableWordsFrom42, HashSet<string> reachableWordsFrom31)
        {
            for (int a = 1; a < 8; a++)
            {
                for (int b = 1; b < 8; b++)
                {
                    // Try out possible a and b values
                    if(IsAMatch(notFoundWord, reachableWordsFrom42, reachableWordsFrom31, a, b))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsAMatch(string notFoundWord, HashSet<string> reachableWordsFrom42, HashSet<string> reachableWordsFrom31, int A, int B)
        {
            for (int a = 0; a < A; a++)
            {
                var matchingPrefixes = notFoundWord.GetMatchingPrefixes(reachableWordsFrom42).ToList();
                if (matchingPrefixes.Count== 0)
                {
                    return false;
                }
                else if (matchingPrefixes.Count == 1)
                {
                    notFoundWord = notFoundWord[matchingPrefixes[0].Length..];
                }
                else
                {
                    // This solution only works if one match found every try
                    throw new Exception();
                }
            }
            for (int b = 0; b < B; b++)
            {
                var matchingPrefixesb = notFoundWord.GetMatchingPrefixes(reachableWordsFrom42).ToList();
                if (matchingPrefixesb.Count == 0)
                {
                    return false;
                }
                else if (matchingPrefixesb.Count == 1)
                {
                    notFoundWord = notFoundWord[matchingPrefixesb[0].Length..];
                }
                else
                {
                    // This solution only works if one match found every try
                    throw new Exception();
                }
                var matchingPostFixes = notFoundWord.GetMatchingPostfixes(reachableWordsFrom31).ToList();
                if (matchingPostFixes.Count == 0)
                {
                    return false;
                }
                else if (matchingPostFixes.Count == 1)
                {
                    notFoundWord = notFoundWord[..^matchingPostFixes[0].Length];
                }
                else
                {
                    // This solution only works if one match found every try
                    throw new Exception();
                }
            }
            if (notFoundWord.Length == 0)
            {
                return true;
            }
            return false;
        }

        private Grammar CreateGrammar(List<string> rulesInput)
        {
            Grammar grammar = new Grammar();
            grammar.AddRules(rulesInput);
            return grammar;
        }

    }

    public static class Extensions
    {
        public static IEnumerable<string> GetMatchingPrefixes(this string str, IEnumerable<string> prefixes)
        {
            foreach (var prefix in prefixes)
            {
                if (str.StartsWith(prefix)) yield return prefix;
            }
        }

        public static IEnumerable<string> GetMatchingPostfixes(this string str, IEnumerable<string> postFixes)
        {
            foreach (var postfix in postFixes)
            {
                if (str.EndsWith(postfix)) yield return postfix;
            }
        }
    }
}

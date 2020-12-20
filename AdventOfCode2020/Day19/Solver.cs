namespace AdventOfCode2020.Day19
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;

    public class Solver : ISolver
    {
        private readonly IEnumerable<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }
        public string GetFirstSolution()
        {
            var grammar = new Grammar();
            var enumerator = input.GetEnumerator();
            var hasNext = enumerator.MoveNext();
            var line = enumerator.Current;
            while (hasNext && !string.IsNullOrWhiteSpace(line))
            {
                var rules = RuleFactory.CreateRules(line);
                rules.ForEach(rule => grammar.AddRule(rule));
                hasNext = enumerator.MoveNext();
                line = enumerator.Current;
            }
            hasNext = enumerator.MoveNext();
            line = enumerator.Current;
            var validWordCount = 0;
            var validWords = new List<string>();
            var notValidWords = new List<string>();
            while (hasNext && !string.IsNullOrWhiteSpace(line))
            {
                if (grammar.IsPartOf(line))
                {
                    validWordCount++;
                    validWords.Add(line);
                }
                else
                {
                    notValidWords.Add(line);
                }
                hasNext = enumerator.MoveNext();
                line = enumerator.Current;
            }
            Console.WriteLine("ValidWords:");
            validWords.Sort();
            validWords.ForEach(Console.WriteLine);
            Console.WriteLine("NOT ValidWords:");
            notValidWords.Sort();
            notValidWords.ForEach(Console.WriteLine);

            return validWordCount.ToString();
        }

        public string GetSecondSolution()
        {
            return "";
        }
    }
}

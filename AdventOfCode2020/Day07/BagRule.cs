using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day07
{
    public class BagRule
    {
        private readonly string containerBag;
        private readonly List<string> containedBags = new List<string>();

        public BagRule(string bagRule)
        {
            var words = bagRule.Split(new[] {' ','.',','}, StringSplitOptions.RemoveEmptyEntries);
            containerBag = string.Join('-', words[0..2]);
            for (int i = 4; i < words.Length; i+=4)
            {
                containedBags.Add(string.Join('-', words[(i + 1)..(i + 3)]));
            }
        }

        public string ContainerBag => containerBag;
        public List<string> ContainedBags => containedBags;

    }
}
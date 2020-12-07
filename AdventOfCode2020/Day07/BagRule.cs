using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day07
{
    public class BagRule
    {
        private readonly string containerBagColor;
        private readonly List<Bag> containedBags = new List<Bag>();

        public BagRule(string bagRule)
        {
            var words = bagRule.Split(new[] {' ','.',','}, StringSplitOptions.RemoveEmptyEntries);
            containerBagColor = string.Join('-', words[0..2]);
            for (int i = 4; i < words.Length; i+=4)
            {
                if (int.TryParse(words[i], out int bagCount))
                {
                    containedBags.Add(new Bag(bagCount, string.Join('-', words[(i + 1)..(i + 3)])));
                }
            }
        }

        public string ContainerBag => containerBagColor;
        public List<Bag> ContainedBags => containedBags;

    }
}
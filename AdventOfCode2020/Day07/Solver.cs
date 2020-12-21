using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day07
{
    public class Solver : ISolver
    {
        private readonly Dictionary<string, BagRule> bagRules;

        public Solver(IEnumerable<BagRule> bagRules)
        {
            this.bagRules = bagRules.ToDictionary(br => br.ContainerBag);
        }

        private readonly Dictionary<string, List<string>> bagsGraph = new Dictionary<string, List<string>>();

        public string GetPartOneSolution()
        {
            foreach (var rule in bagRules)
            {
                foreach (var containedBag in rule.Value.ContainedBags)
                {
                    if (bagsGraph.ContainsKey(containedBag.Color))
                    {
                        bagsGraph[containedBag.Color].Add(rule.Value.ContainerBag);
                    }
                    else
                    {
                        bagsGraph[containedBag.Color] = new List<string> { rule.Value.ContainerBag };
                    }
                }
            }

            HashSet<string> bagsContainAtLeastOneShinyGoldBag = new HashSet<string>();
            Queue<string> bagsToCheck = new Queue<string>();
            bagsToCheck.Enqueue("shiny-gold");
            while (bagsToCheck.Count > 0)
            {
                var bagToExpand = bagsToCheck.Dequeue();
                if (bagsGraph.TryGetValue(bagToExpand, out var containerBags))
                {
                    foreach (var notYetDiscoveredBag in containerBags.Where(cb => !bagsContainAtLeastOneShinyGoldBag.Contains(cb)))
                    {
                        bagsContainAtLeastOneShinyGoldBag.Add(notYetDiscoveredBag);
                        bagsToCheck.Enqueue(notYetDiscoveredBag);
                    }
                }
            }

            return bagsContainAtLeastOneShinyGoldBag.Count.ToString();
        }

        public string GetPartTwoSolution()
        {
            decimal bagsInShinyGoldCount = 0;
            Queue<Bag> bagsInSinyGold = new Queue<Bag>();
            bagRules["shiny-gold"].ContainedBags.ForEach(b => bagsInSinyGold.Enqueue(b));
            while (bagsInSinyGold.Count > 0)
            {
                var currentBag = bagsInSinyGold.Dequeue();
                bagsInShinyGoldCount += currentBag.Count;
                bagRules[currentBag.Color].ContainedBags.ForEach(b => bagsInSinyGold.Enqueue(b with { Count = b.Count * currentBag.Count}));
            }
            return bagsInShinyGoldCount.ToString();
        }
    }
}
using AdventOfCode2020.Common;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day07
{
    public class Solver : ISolver
    {
        private readonly IEnumerable<BagRule> bagRules;

        public Solver(IEnumerable<BagRule> bagRules)
        {
            this.bagRules = bagRules;
        }

        private readonly Dictionary<string, List<string>> bagsGraph = new Dictionary<string, List<string>>();

        public string GetFirstSolution()
        {
            foreach (var rule in bagRules)
            {
                foreach (var containedBag in rule.ContainedBags)
                {
                    if (bagsGraph.ContainsKey(containedBag))
                    {
                        bagsGraph[containedBag].Add(rule.ContainerBag);
                    }
                    else
                    {
                        bagsGraph[containedBag] = new List<string> { rule.ContainerBag };
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

        public string GetSecondSolution()
        {
            return "";
        }
    }
}
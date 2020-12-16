namespace AdventOfCode2020.Day16
{
    using AdventOfCode2020.Common;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Solver : ISolver
    {
        private const int VALID = 1;
        private readonly IEnumerable<string> input;
        private List<Rule> rules;
        private Ticket myTicket;
        private List<Ticket> nearByTickets;
        private List<Ticket> validNeatByTickets;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }

        private void Initialize()
        {
            rules = new List<Rule>();
            var enumerator = input.GetEnumerator();
            enumerator.MoveNext();
            while (!string.IsNullOrEmpty(enumerator.Current))
            {
                rules.Add(new Rule(enumerator.Current));
                enumerator.MoveNext();
            }
            enumerator.MoveNext();

            Debug.WriteLine(enumerator.Current);
            enumerator.MoveNext();
            myTicket = new Ticket(enumerator.Current);
            enumerator.MoveNext();

            enumerator.MoveNext();
            Debug.WriteLine(enumerator.Current);
            nearByTickets = new List<Ticket>();
            while (enumerator.MoveNext())
            {
                nearByTickets.Add(new Ticket(enumerator.Current));
            }
        }

        public string GetFirstSolution()
        {
            Initialize();
            int ticketScanningErrorRate = GetTicketScanningErrorRate();
            return ticketScanningErrorRate.ToString();
        }

        private int GetTicketScanningErrorRate()
        {
            var ticketScanningErrorRate = 0;
            int[] numbers = new int[1000];
            foreach (var rule in rules)
            {
                foreach (var number in rule.GetValidNumbers())
                {
                    numbers[number] = VALID;
                }
            }
            validNeatByTickets = new List<Ticket>();
            foreach (var ticket in nearByTickets)
            {
                bool isValidTicket = true;
                foreach (var number in ticket.Numbers)
                {
                    if (numbers[number] != VALID)
                    {
                        ticketScanningErrorRate += number;
                        isValidTicket = false;
                    }
                }
                if (isValidTicket)
                {
                    validNeatByTickets.Add(ticket);
                }
            }

            return ticketScanningErrorRate;
        }

        public string GetSecondSolution()
        {
            Initialize();
            if (validNeatByTickets is null)
            {
                GetTicketScanningErrorRate();
            }
            var rulesValidPositions = new Dictionary<string, List<int>>();
            foreach (var rule in rules)
            {
                rulesValidPositions[rule.RuleName] = new List<int>();
                for (int i = 0; i < myTicket.Numbers.Count; i++)
                {
                    bool ruleValidForPosition = true;
                    foreach (var ticket in validNeatByTickets)
                    {
                        if (!rule.IsValid(ticket.Numbers[i]))
                        {
                            ruleValidForPosition = false;
                            break;
                        }
                    }
                    if (ruleValidForPosition)
                    {
                        rulesValidPositions[rule.RuleName].Add(i);
                    }
                }
            }
            var orderedDict = rulesValidPositions.OrderBy(c => c.Value.Count);
            var rulesPositions = new Dictionary<int, string>();
            foreach (var ruleWithValidPositionList in orderedDict)
            {
                var position = ruleWithValidPositionList.Value.FirstOrDefault(p => !rulesPositions.ContainsKey(p));
                var ruleName = ruleWithValidPositionList.Key;
                rulesPositions.Add(position, ruleName);
            }
            var departurePositions = rulesPositions
                .Where(kv => kv.Value.StartsWith("departure"))
                .Select(KeyValuePair => KeyValuePair.Key)
                .ToHashSet();
            var result = departurePositions.Aggregate(1L, (s, pos) =>
            {
                return s * myTicket[pos];
            });
            return result.ToString();
        }
    }
}

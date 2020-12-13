namespace AdventOfCode2020.Day13
{
    using AdventOfCode2020.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly List<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input.ToList();
        }

        #region partOne
        public string GetFirstSolution()
        {
            var timestampNow = int.Parse(input[0]);
            var buses = GetBuses(input[1]);
            var minWaitTime = int.MaxValue;
            var minWaitBusId = -1;
            foreach (var busId in buses)
            {
                int timeShouldWait = GetWaitTime(timestampNow, busId);
                if (timeShouldWait < minWaitTime)
                {
                    minWaitTime = timeShouldWait;
                    minWaitBusId = busId;
                }
            }
            return (minWaitBusId * minWaitTime).ToString();
        }

        private int GetWaitTime(int timestampNow, int busId)
        {
            var remainder = timestampNow % busId;
            if (remainder == 0) return 0;
            else return busId - remainder;
        }

        private IEnumerable<int> GetBuses(string buses) => buses.Split(',').Where(s => s != "x").Select(int.Parse);
        #endregion
        #region partTwo
        /// <summary>
        /// Calculate solution used Chinese remainder theorem
        /// https://en.wikipedia.org/wiki/Chinese_remainder_theorem
        /// </summary>
        /// <returns></returns>
        public string GetSecondSolution()
        {
            var busIdList = input[1].Split(',');
            List<Bus> buses = new List<Bus>();
            for (int i = 0; i < busIdList.Length; i++)
            {
                if (int.TryParse(busIdList[i], out var id))
                {
                    buses.Add(new Bus(id, i));
                }
            }

            var M = buses.Aggregate(1M, (d, b) => d * b.Id);

            var sum = buses.Sum(b => b.CalculateAiXMiXNi(M)) % M;
            while (sum < 0) 
            {
                sum += M;
            }

            return (sum % M).ToString();
        }
        #endregion
    }
}

namespace AdventOfCode2020.Day23
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CrabGame
    {
        private Cup actualCup;
        private readonly Cup[] cupsList;
        private readonly int highestValueOnAnyCup;
        private readonly int lowestValueOnAnyCup;

        public CrabGame(IEnumerable<int> cupsNumbers)
        {
            highestValueOnAnyCup = cupsNumbers.Max();
            lowestValueOnAnyCup = 1;
            cupsList = new Cup[highestValueOnAnyCup + 1];
            var startCup = new Cup(cupsNumbers.First());
            cupsList[startCup.CupNo] = startCup;
            var previousCup = startCup;
            foreach (var cupsNumber in cupsNumbers.Skip(1))
            {
                var newCup = new Cup(cupsNumber);
                cupsList[newCup.CupNo] = newCup;
                newCup.PreviousCup = previousCup;
                previousCup.NextCup = newCup;
                previousCup = newCup;
            }
            previousCup.NextCup = startCup;
            startCup.PreviousCup = previousCup;
            actualCup = startCup;
        }

        public string GetTwoNumbersMultipliedAfterCupOne()
        {
            var cupOne = cupsList[1];
            var next1 = cupOne.NextCup;
            var next2 = cupOne.NextCup.NextCup;
            return (next1.CupNo * (decimal)next2.CupNo).ToString();
        }

        public string GetNumbersAfterOne()
        {
            var result = new StringBuilder();
            var cupOne = cupsList[1];
            var cupNext = cupOne.NextCup;
            while (cupNext != cupOne)
            {
                result.Append(cupNext.CupNo);
                cupNext = cupNext.NextCup;
            }
            return result.ToString();
        }

        public void DoShuffle()
        {
            // Remove 3 cup next to actual
            var nextCup1 = actualCup.NextCup;
            var nextCup2 = nextCup1.NextCup;
            var nextCup3 = nextCup2.NextCup;

            actualCup.NextCup = nextCup3.NextCup;
            actualCup.NextCup.PreviousCup = actualCup;

            // Find destination cup: actual minus one value
            var searchedCupNo = actualCup.CupNo - 1;
            if (searchedCupNo < lowestValueOnAnyCup)
            {
                searchedCupNo = highestValueOnAnyCup;
            }
            while (searchedCupNo == nextCup1.CupNo || searchedCupNo == nextCup2.CupNo || searchedCupNo == nextCup3.CupNo)
            {
                searchedCupNo--;
                if (searchedCupNo < lowestValueOnAnyCup)
                {
                    searchedCupNo = highestValueOnAnyCup;
                }
            }

            // Put removed cups to place
            var destinationCup = cupsList[searchedCupNo];
            var destinationOriginalNextCup = destinationCup.NextCup;
            destinationCup.NextCup = nextCup1;
            nextCup1.PreviousCup = destinationCup;
            nextCup3.NextCup = destinationOriginalNextCup;
            destinationOriginalNextCup.PreviousCup = nextCup3;

            // Step actual cup one
            actualCup = actualCup.NextCup;
        }
    }
}

using AdventOfCode2020.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    public class Solver : ISolver
    {
        private readonly List<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input.ToList();
        }

        public string GetFirstSolution()
        {
            return GetAnswerCount(pg =>pg.AnyAnswerCount);
        }

        public string GetSecondSolution()
        {
            return GetAnswerCount(pg => pg.AllAnswerCount);
        }

        private string GetAnswerCount(Func<PassangerGroup,int> countFunc)
        {
            PassangerGroup passangerGroup = new PassangerGroup();
            int answerCount = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {
                    answerCount += countFunc(passangerGroup);
                    passangerGroup = new PassangerGroup();
                }
                else
                {
                    passangerGroup.AddAnswer(input[i]);
                }
            }
            answerCount += countFunc(passangerGroup);
            return answerCount.ToString();
        }

    }
}

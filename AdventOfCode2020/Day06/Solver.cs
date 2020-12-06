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
            PassangerGroup passangerGroup = new PassangerGroup();
            int answerCount = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {
                    answerCount += passangerGroup.AnswerCount;
                    passangerGroup = new PassangerGroup();
                }
                else
                {
                    passangerGroup.AddAnswer(input[i]);
                }
            }
            answerCount += passangerGroup.AnswerCount;
            return answerCount.ToString();
        }

        public string GetSecondSolution()
        {
            return "";
        }
    }
}

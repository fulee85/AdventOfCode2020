using System.Collections.Generic;

namespace AdventOfCode2020.Day06
{
    public class PassangerGroup
    {
        private readonly HashSet<char> answers = new HashSet<char>();
        public void AddAnswer(string answer)
        {
            foreach (var ch in answer)
            {
                answers.Add(ch);
            }
        }

        public int AnswerCount => answers.Count;
    }
}
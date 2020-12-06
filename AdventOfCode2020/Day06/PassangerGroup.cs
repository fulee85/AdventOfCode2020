using System.Collections.Generic;

namespace AdventOfCode2020.Day06
{
    public class PassangerGroup
    {
        private readonly HashSet<char> anyAnswers = new HashSet<char>();
        private readonly HashSet<char> allAnswers = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
        public void AddAnswer(string answer)
        {
            anyAnswers.UnionWith(answer);
            allAnswers.IntersectWith(answer);
        }

        public int AnyAnswerCount => anyAnswers.Count;

        public int AllAnswerCount => allAnswers.Count;
    }
}
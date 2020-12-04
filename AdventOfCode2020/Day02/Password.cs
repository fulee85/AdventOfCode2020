using AdventOfCode2020.Common;
using System;
using System.Linq;

namespace AdventOfCode2020.Day02
{
    public class Password
    {
        private readonly int firstParam;
        private readonly int secondParam;
        private readonly char character;
        private readonly string word;

        public static Password Parse(string arg)
        {
            var parts = arg.Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            int firstParam = int.Parse(parts[0]);
            int secondParam = int.Parse(parts[1]);
            char character = parts[2][0];
            string word = parts[3];
            return new Password(firstParam, secondParam, character, word);
        }

        public Password(int firstParam, int secondParam, char character, string word)
        {
            this.firstParam = firstParam;
            this.secondParam = secondParam;
            this.character = character;
            this.word = word;
        }

        public bool IsValidSledRental => word.Count(c => c.Equals(character)).IsBetween(firstParam, secondParam);

        public bool IsValidAtToboggan
        {
            get
            {
                char charAtFirstParam = word[firstParam - 1];
                char charAtSecondParam = word[secondParam - 1];
                return charAtFirstParam == character ^ charAtSecondParam == character;
            }
        }
    }
}

namespace AdventOfCode2020.Day21
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Food
    { 
        private readonly string[] ingredients;
        private readonly string[] allergens;

        public Food(string s)
        {
            ingredients = new string(s.TakeWhile(c => c != '(').ToArray()).Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var allergensPart = new string(s.SkipWhile(c => c != '(').ToArray());
            if (!string.IsNullOrWhiteSpace(allergensPart))
            {
                allergens = allergensPart["(contains ".Length..^1].Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public IEnumerable<string> Allergens => allergens;
        public IEnumerable<string> Ingredients => ingredients;
    }
}

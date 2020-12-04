using System.Collections.Generic;

namespace AdventOfCode2020.Day04.Validators
{
    public class EyeColorValidator : IValidator
    {
        public string FieldName => "ecl";

        private readonly HashSet<string> eyeColors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public bool Validate(string s)
        {
            return eyeColors.Contains(s);
        }
    }
}

using System;

namespace AdventOfCode2020.Day04.Validators
{
    public class HeightValidator : IValidator
    {
        public string FieldName => "hgt";

        public bool Validate(string s)
        {
            var dimension = s[^2..];
            if (!int.TryParse(s[..^2], out int value))
            {
                throw new Exception($"value is not an integer! {s[..^2]}");
            }
            return dimension switch
            {
                "cm" => 150 <= value && value <= 193,
                "in" => 59 <= value && value <= 76,
                _ => false,
            };
        }
    }
}

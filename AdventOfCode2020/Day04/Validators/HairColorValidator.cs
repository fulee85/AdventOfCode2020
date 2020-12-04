using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04.Validators
{
    public class HairColorValidator : IValidator
    {
        public string FieldName => "hcl";

        public bool Validate(string s)
        {
            var regex = new Regex(@"^#[0-9a-f]{6}$");
            return regex.IsMatch(s);
        }
    }
}

using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04.Validators
{
    public class PassportIDValidator : IValidator
    {
        public string FieldName => "pid";

        public bool Validate(string s)
        {
            var regex = new Regex(@"^[0-9]{9}$");
            return regex.IsMatch(s);
        }
    }
}

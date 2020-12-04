namespace AdventOfCode2020.Day04.Validators
{
    public class IssueYearValidator : YearValidator, IValidator
    {
        public string FieldName => "iyr";

        public IssueYearValidator()
        {
            fromYear = 2010;
            toYear = 2020;
        }
    }
}

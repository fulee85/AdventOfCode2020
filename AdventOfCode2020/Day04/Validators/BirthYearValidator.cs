namespace AdventOfCode2020.Day04.Validators
{
    public class BirthYearValidator : YearValidator, IValidator
    {
        public string FieldName => "byr";

        public BirthYearValidator()
        {
            fromYear = 1920;
            toYear = 2002;
        }
    }
}

namespace AdventOfCode2020.Day04.Validators
{
    public abstract class YearValidator
    {
        protected int fromYear;
        protected int toYear;

        public bool Validate(string s)
        {
            if (int.TryParse(s, out int value))
            {
                return fromYear <= value && value <= toYear;
            }
            return false;
        }
    }
}

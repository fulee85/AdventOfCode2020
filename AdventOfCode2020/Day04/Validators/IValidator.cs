namespace AdventOfCode2020.Day04.Validators
{
    public interface IValidator
    {
        string FieldName { get; }
        bool Validate(string s);
    }
}

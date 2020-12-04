using AdventOfCode2020.Day04.Validators;
using System.Collections.Generic;

namespace AdventOfCode2020.Day04
{
    public class StrictPassport : Passport
    {
        private readonly List<IValidator> validators = new List<IValidator>
        {
            new BirthYearValidator(),
            new ExpirationYearValidator(),
            new EyeColorValidator(),
            new HairColorValidator(),
            new HeightValidator(),
            new IssueYearValidator(),
            new PassportIDValidator(),
        };

        public override bool IsValid()
        {
            bool isValid = base.IsValid();
            foreach (var validator in validators)
            {
                if (!isValid) break;
                if (data.TryGetValue(validator.FieldName, out string fieldValue))
                {
                    isValid &= validator.Validate(fieldValue);
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}

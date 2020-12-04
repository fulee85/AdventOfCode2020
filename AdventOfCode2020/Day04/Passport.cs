using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day04
{
    public class Passport
    {
        private readonly Dictionary<string, string> data = new Dictionary<string, string>();
        private readonly List<string> requiredFields = new List<string> { 
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
        };

        public void AddField(string field)
        {
            var fieldPts = field.Split(':');
            if (fieldPts.Length != 2)
            {
                throw new ArgumentException($"Value of field is not acceptable. Field: {field}");
            }
            var fieldName = fieldPts[0].Trim();
            var fieldValue = fieldPts[1].Trim();
            data.TryAdd(fieldName, fieldValue);
        }

        public bool IsValid => requiredFields.All(rqf => data.ContainsKey(rqf));
    }
}

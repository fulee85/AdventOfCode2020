using AdventOfCode2020.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day04
{
    public class Solver : ISolver
    {
        private readonly IEnumerable<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }

        public string GetFirstSolution()
        {
            int validPassports = 0;
            Passport actualPassport = new Passport();
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (actualPassport.IsValid)
                    {
                        validPassports++;
                    }
                    actualPassport = new Passport();
                }
                else
                {
                    foreach (var field in line.Split())
                    {
                        actualPassport.AddField(field);
                    }
                }
            }
            if (actualPassport.IsValid)
            {
                validPassports++;
            }
            return validPassports.ToString();
        }

        public string GetSecondSolution()
        {
            return string.Empty;
        }
    }
}

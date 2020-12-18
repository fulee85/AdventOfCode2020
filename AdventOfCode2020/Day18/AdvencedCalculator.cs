namespace AdventOfCode2020.Day18
{
    using System;

    public class AdvencedCalculator : Calculator
    {
        protected override int Prec(string op) => op switch
        {
            "+" => 1,
            "*" => 0,
            _ => -1
        };
    }
}

using AdventOfCode2020.Common;
using AdventOfCode2020.Day21;
using System;
using System.Linq;

namespace AdventOfCode2020
{
    public static class SolverFactory
    {
        public static ISolver GetSolver(int day) => day switch
        {
            1 => new Day01.Solver(new Input<int>("01", int.Parse)),
            2 => new Day02.Solver(new Input<Day02.Password>("02", Day02.Password.Parse)),
            3 => new Day03.Solver(new Input<string>("03", s => s)),
            4 => new Day04.Solver(new Input<string>("04", s => s)),
            5 => new Day05.Solver(new Input<Day05.BoardingPass>("05", s => new Day05.BoardingPass(s))),
            6 => new Day06.Solver(new Input<string>("06", s => s)),
            7 => new Day07.Solver(new Input<Day07.BagRule>("07", s => new Day07.BagRule(s))),
            8 => new Day08.Solver(new Input<Day08.Instruction>("08", s => new Day08.Instruction(s))),
            9 => new Day09.Solver(new Input<long>("09", long.Parse)),
            10 => new Day10.Solver(new Input<int>("10", int.Parse)),
            11 => new Day11.Solver(new Input<string>("11", s => s)),
            12 => new Day12.Solver(new Input<string>("12", s => s)),
            13 => new Day13.Solver(new Input<string>("13", s => s)),
            14 => new Day14.Solver(new Input<string>("14", s => s)),
            15 => new Day15.Solver(new Input<string>("15", s => s).First()),
            16 => new Day16.Solver(new Input<string>("16", s => s)),
            17 => new Day17.Solver(new Input<string>("17", s => s).ToList()),
            18 => new Day18.Solver(new Input<string>("18", s => s)),
            19 => new Day19.Solver(new Input<string>("19", s => s)),
            20 => new Day20.Solver(new Input<string>("20", s => s)),
            21 => new Day21.Solver(new Input<Food>("21", s => new Food(s))),
            22 => new Day22.Solver(new Input<string>("22", s => s)),
            23 => new Day23.Solver("158937462"),
            24 => new Day24.Solver(new Input<Day24.Instruction>("24", s => new Day24.Instruction(s))),
            _ => throw new Exception()
        };
    }
}

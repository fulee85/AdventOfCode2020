namespace Tests
{
    using AdventOfCode2020.Common;
    using AdventOfCode2020.Day19;
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Day19Tests
    {
        private readonly List<string> testInput1 = new List<string>(
@"0: 4 1
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""

ababb
babab
abbba
aaabb
aaaabb
ababb".Split(Environment.NewLine));

        [Fact]
        public void PartOneTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetFirstSolution().Should().Be("3");
        }

        private readonly List<string> testInput2 = new List<string>(
@"0: 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""

babbb
ababa
bbbab
aabbb
aaabbb".Split(Environment.NewLine));
        [Fact]
        public void PartOneTest2()
        {
            ISolver solver = new Solver(testInput2);
            solver.GetFirstSolution().Should().Be("2");
        }

        private readonly List<string> testInput3 = new List<string>(
@"0: 8 11
8: 42
11: 42 2
42: 120 16 | 2 2
120: ""b""
16: 2 120 | 120 2
2: ""a""

babbaba
babbbaa 
babaaa 
bbababa  
bbabbaa 
bbaaaa
aababa
aabbaa 
aaaaa".Split(Environment.NewLine));
        [Fact]
        public void PartOneTest3()
        {
            ISolver solver = new Solver(testInput3);
            solver.GetFirstSolution().Should().Be("9");
        }

        private readonly List<string> testInput4 = new List<string>(
@"0: 1 2
1: ""a""
2: 1 3 | 3 1
3: ""b""

bab
bbb 
aab
aba
bba".Split(Environment.NewLine));
        [Fact]
        public void PartOneTest4()
        {
            ISolver solver = new Solver(testInput4);
            solver.GetFirstSolution().Should().Be("2");
        }

        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInput1);
            solver.GetSecondSolution().Should().Be("");
        }
    }
}

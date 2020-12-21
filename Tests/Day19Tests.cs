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
            solver.GetPartOneSolution().Should().Be("3");
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
            solver.GetPartOneSolution().Should().Be("2");
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
            solver.GetPartOneSolution().Should().Be("9");
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
            solver.GetPartOneSolution().Should().Be("2");
        }

        private readonly List<string> testInputPartTwo = new List<string>(
@"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1

abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaaaabbaaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
babaaabbbaaabaababbaabababaaab
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba".Split(Environment.NewLine));
        [Fact]
        public void PartTwoTest1()
        {
            ISolver solver = new Solver(testInputPartTwo);
            solver.GetPartTwoSolution().Should().Be("12");
        }
    }
}

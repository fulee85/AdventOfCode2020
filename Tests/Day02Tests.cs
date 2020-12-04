using AdventOfCode2020.Common;
using AdventOfCode2020.Day02;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Day02Tests
    {
        [Fact]
        public void PasswordTest1()
        {
            var pw = Password.Parse("1-3 a: abcde");
            pw.IsValidSledRental.Should().BeTrue();
        }

        [Fact]
        public void SolverTest1()
        {
            ISolver solver = new Solver(new List<Password> {
                new Password(1, 3, 'a', "abcde"),
                new Password(1, 3, 'b', "cdefg"),
                new Password(2, 9, 'c', "ccccccccc"),
            });
            solver.GetFirstSolution().Should().Be("2");
        }

        [Fact]
        public void SolverTest2()
        {
            ISolver solver = new Solver(new List<Password> {
                new Password(1, 3, 'a', "abcde"),
                new Password(1, 3, 'b', "cdefg"),
                new Password(2, 9, 'c', "ccccccccc")
            });
            solver.GetSecondSolution().Should().Be("1");
        }
    }
}

using AdventOfCode2020.Day05;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class Day05Tests
    {
        [Fact]
        public void BoardingPassTest1()
        {
            var boardingPass = new BoardingPass("BFFFBBFRRR");
            boardingPass.SeatId.Should().Be(567);
            var boardingPass1 = new BoardingPass("FFFBBBFRRR");
            boardingPass1.SeatId.Should().Be(119);
            var boardingPass2 = new BoardingPass("BBFFBBFRLL");
            boardingPass2.SeatId.Should().Be(820);
        }
    }
}

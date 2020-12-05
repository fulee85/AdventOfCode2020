using System;

namespace AdventOfCode2020.Day05
{
    public class BoardingPass
    {
        private readonly string seatCode;

        public BoardingPass(string seatCode)
        {
            this.seatCode = seatCode
                .Replace('B', '1')
                .Replace('F', '0')
                .Replace('R', '1')
                .Replace('L', '0');
        }

        public int SeatId => Convert.ToInt32(seatCode, 2);
    }
}
namespace AdventOfCode2020.Day23
{
    using System;

    public class Cup
    {
        public Cup(int cupNo)
        {
            CupNo = cupNo;
        }
        public int CupNo { get; set; }
        public Cup NextCup { get; set; }
        public Cup PreviousCup { get; set; }
    }
}

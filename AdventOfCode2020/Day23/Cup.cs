namespace AdventOfCode2020.Day23
{
    public class Cup
    {
        public Cup(int cupNo)
        {
            CupNo = cupNo;
        }
        public int CupNo { get; set; }
        public Cup NextCup { get; set; }
    }
}

namespace AdventOfCode2020.Day10
{
    using System;

    public class ListElement
    {
        public ListElement(int jolt)
        {
            Jolt = jolt;
        }

        public decimal PossibleRoutesFromHere { get; set; }

        public int Jolt { get; }
    }
}

namespace AdventOfCode2020.Day14.PartOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PortComputer
    {
        private readonly Dictionary<int, long> memory = new Dictionary<int, long>();
        private Mask mask;

        public void ProcessInstruction(string s)
        {
            if (s.StartsWith("mask"))
            {
                SetMask(s);
            }
            else
            {
                SetMemory(s);
            }
        }

        private void SetMask(string s)
        {
            var maskValue = s.Split().Last();
            mask = new Mask(maskValue);
        }

        private void SetMemory(string s)
        {
            var values = s.Split(new char[] { ' ', '[', ']', '=' }, StringSplitOptions.RemoveEmptyEntries);
            int address = int.Parse(values[1]);
            long value = long.Parse(values[2]);
            memory[address] = mask.GetMaskedValue(value);
        }

        public long GetMemorySum() => memory.Values.Sum();
    }
}

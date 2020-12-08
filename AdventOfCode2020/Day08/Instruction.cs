namespace AdventOfCode2020.Day08
{
    public record Instruction
    {
        public Instruction(string s)
        {
            var parts = s.Split();
            Operation = parts[0];
            Parameter = int.Parse(parts[1]);
        }

        public string Operation { get; set; }
        public int Parameter { get; private set; }
    }
}
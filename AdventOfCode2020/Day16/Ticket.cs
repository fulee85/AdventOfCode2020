namespace AdventOfCode2020.Day16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ticket
    {
        private readonly List<int> numbers;

        public Ticket(string numbers)
        {
            this.numbers = numbers.Split(',').Select(int.Parse).ToList();
        }

        public List<int> Numbers => numbers;

        public int this[int index] => numbers[index];
    }
}

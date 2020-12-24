namespace AdventOfCode2020.Day24
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Instruction : IEnumerable<Directions>
    {
        private readonly string inputLine;

        public Instruction(string inputLine)
        {
            this.inputLine = inputLine;
        }

        public IEnumerator<Directions> GetEnumerator()
        {
            for (int i = 0; i < inputLine.Length; i++)
            {
                yield return inputLine[i] switch
                {
                    'e' => Directions.east,
                    'w' => Directions.west,
                    'n' when (inputLine[i + 1] == 'e') => Directions.northeast, 
                    'n' when (inputLine[i + 1] == 'w') => Directions.northwest, 
                    's' when (inputLine[i + 1] == 'e') => Directions.southeast, 
                    's' when (inputLine[i + 1] == 'w') => Directions.southwest, 
                    _ => throw new Exception()
                };
                if (inputLine[i]  == 'n' || inputLine[i] == 's')
                {
                    i++;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

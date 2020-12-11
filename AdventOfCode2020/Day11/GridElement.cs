namespace AdventOfCode2020.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public record GridElement
    {
        private readonly List<GridElement> neighbourChairs = new List<GridElement>();
        public GridElement(char ch, bool isOccupied = false)
        {
            IsChair = ch == 'L';
            IsOccupied = isOccupied;
        }

        public bool IsChair { get; private set; }
        public bool IsOccupied { get; private set; }
        public bool IsOccupiedNext { get; private set; }

        public void AddNeighbour(GridElement neighbour)
        {
            if (neighbour.IsChair)
            {
                neighbourChairs.Add(neighbour);
            }
        }

        public void CalculateNextState(int tolerance)
        {
            if (IsOccupied && neighbourChairs.Count(c => c.IsOccupied) >= tolerance)
            {
                IsOccupiedNext = false;
            }
            else if (!IsOccupied && neighbourChairs.All(c => !c.IsOccupied))
            {
                IsOccupiedNext = true;
            }
        }

        public bool Update()
        {
            bool isChanged = IsOccupied != IsOccupiedNext;
            IsOccupied = IsOccupiedNext;
            return isChanged;
        }
    }
}

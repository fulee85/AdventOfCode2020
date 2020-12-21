namespace AdventOfCode2020.Day11
{
    using AdventOfCode2020.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Solver : ISolver
    {
        private readonly IEnumerable<string> input;
        private List<List<GridElement>> seating;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }

        private void Init()
        {
            seating = new List<List<GridElement>>();
            foreach (var row in input)
            {
                var rowElements = new List<GridElement>();
                foreach (var ch in row)
                {
                    rowElements.Add(new GridElement(ch));
                }
                seating.Add(rowElements);
            }
        }

        public string GetPartOneSolution()
        {
            Init();
            List<GridElement> chairs = new List<GridElement>();
            for (int i = 0; i < seating.Count; i++)
            {
                for (int j = 0; j < seating[i].Count; j++)
                {
                    if (seating[i][j].IsChair)
                    {
                        AddNeighbours(i, j);
                        chairs.Add(seating[i][j]);
                    }
                }
            }

            bool changeHappened = true;
            while (changeHappened)
            {
                foreach (var chair in chairs)
                {
                    chair.CalculateNextState(4);
                }
                bool AnyChange = false;
                foreach (var chair in chairs)
                {
                    AnyChange |= chair.Update();
                }
                changeHappened = AnyChange;
            }
            return chairs.Count(c => c.IsOccupied).ToString();

            void AddNeighbours(int i, int j)
            {
                for (int iDiff = -1; iDiff <= 1; iDiff++)
                {
                    for (int jDiff = -1; jDiff <= 1; jDiff++)
                    {
                        if (iDiff == 0 && jDiff == 0) continue;
                        int iAkt = i + iDiff;
                        int jAkt = j + jDiff;
                        if (iAkt >= 0 && iAkt < seating.Count && jAkt >= 0 && jAkt < seating[i].Count)
                        {
                            seating[i][j].AddNeighbour(seating[iAkt][jAkt]);
                        }
                    }
                }
            }
        }

        public string GetPartTwoSolution()
        {
            Init();
            List<GridElement> chairs = new List<GridElement>();
            for (int i = 0; i < seating.Count; i++)
            {
                for (int j = 0; j < seating[i].Count; j++)
                {
                    if (seating[i][j].IsChair)
                    {
                        AddNeighbours(i, j);
                        chairs.Add(seating[i][j]);
                    }
                }
            }

            bool changeHappened = true;
            while (changeHappened)
            {
                foreach (var chair in chairs)
                {
                    chair.CalculateNextState(5);
                }
                bool AnyChange = false;
                foreach (var chair in chairs)
                {
                    AnyChange |= chair.Update();
                }
                changeHappened = AnyChange;
            }
            return chairs.Count(c => c.IsOccupied).ToString();

            void AddNeighbours(int i, int j)
            {
                directions.ForEach(d => AddNeighbourInDirection(new Position(i, j, seating.Count, seating[0].Count), d));
            }
        }

        private void AddNeighbourInDirection(Position position, Directions dir)
        {
            foreach (var element in position.GetPositionsInDirection(dir))
            {
                if (seating[element.Row][element.Col].IsChair)
                {
                    seating[position.Row][position.Col].AddNeighbour(seating[element.Row][element.Col]);
                    break;
                }
            }
        }

        private List<Directions> directions = new List<Directions> 
        { Directions.Up, Directions.Down, Directions.Left, Directions.Right, 
            Directions.UpRight, Directions.UpLeft, Directions.DownRight, Directions.DownLeft };
    }
}

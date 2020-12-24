using System.Collections.Generic;

namespace AdventOfCode2020.Day24
{
    public record TilePosition(int X, int Y)
    {
        public IEnumerable<TilePosition> GetAdjacentPositions()
        {
            yield return this with { X = X + 2 };
            yield return this with { X = X - 2 };
            yield return this with { X = X - 1, Y = Y + 1 };
            yield return this with { X = X - 1, Y = Y - 1 };
            yield return this with { X = X + 1, Y = Y + 1 };
            yield return this with { X = X + 1, Y = Y - 1 };
        }

        public static TilePosition Create(IEnumerable<Directions> instruction)
        {
            int x = 0, y = 0;
            foreach (var direction in instruction)
            {
                switch (direction)
                {
                    case Directions.east:
                        x -=2;
                        break;
                    case Directions.northeast:
                        x--; y++; 
                        break;
                    case Directions.southeast:
                        x--; y--;
                        break;
                    case Directions.west:
                        x += 2;
                        break;
                    case Directions.northwest:
                        x++; y++;
                        break;
                    case Directions.southwest:
                        x++; y--;
                        break;
                    default:
                        break;
                }
            }
            return new TilePosition(x, y);
        }
    }
}

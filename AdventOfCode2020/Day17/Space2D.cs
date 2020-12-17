namespace AdventOfCode2020.Day17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Space2D : ISpace
    {
        protected readonly HashSet<ISpaceCube> allSpaceParts = new HashSet<ISpaceCube>();
        protected readonly HashSet<ISpaceCube> activeSpaceParts = new HashSet<ISpaceCube>();

        public int GetActivePartsCount()
        {
            return activeSpaceParts.Count;
        }

        public ISpaceCube GetSpacePart(int x, int y, int z, int w)
        {
            if (allSpaceParts.TryGetValue(CreateSpaceCube(x, y, z, w), out var part))
            {
                return part;
            }
            var newSpacePart = CreateSpaceCube(x, y, z, w);
            allSpaceParts.Add(newSpacePart);
            return newSpacePart;
        }

        protected virtual ISpaceCube CreateSpaceCube(int x, int y, int z, int w)
        {
            return new SpaceCube2D(x,y,z);
        }

        public void SetActivePart(int x, int y)
        {
            var spacePart = GetSpacePart(x, y, 0, 0);
            spacePart.IsActive = true;
            activeSpaceParts.Add(spacePart);
        }

        public void Step()
        {
            var spacePartsShouldCheck = new HashSet<ISpaceCube>();
            foreach (var activeSpacePart in activeSpaceParts)
            {
                spacePartsShouldCheck.Add(activeSpacePart);
                foreach (ISpaceCube item in activeSpacePart.GetNeighbours(this))
                {
                    spacePartsShouldCheck.Add(item);
                }
            }

            var changeableParts = new List<ISpaceCube>();
            foreach (var spacePart in spacePartsShouldCheck)
            {
                spacePart.CalculateNextStatus(this);
                if (spacePart.IsActive != spacePart.IsActiveNext)
                {
                    changeableParts.Add(spacePart);
                }
            }
            foreach (var part in changeableParts)
            {
                part.Change();
                if (part.IsActive)
                {
                    activeSpaceParts.Add(part);
                }
                else
                {
                    activeSpaceParts.Remove(part);
                }
            }
        }
    }
}

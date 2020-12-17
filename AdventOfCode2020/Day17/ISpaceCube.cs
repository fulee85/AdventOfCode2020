namespace AdventOfCode2020.Day17
{
    using System;
    using System.Collections.Generic;

    public interface ISpaceCube
    {
        bool IsActive { get; set; }
        bool IsActiveNext { get; set; }

        IEnumerable<ISpaceCube> GetNeighbours(ISpace space);
        void CalculateNextStatus(ISpace space);
        void Change();
    }
}

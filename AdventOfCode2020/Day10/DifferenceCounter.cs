// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DifferenceCount.cs" company="One Identity Inc.">
//   ONE IDENTITY LLC. PROPRIETARY INFORMATION
//
//   This software is confidential.  One Identity, LLC. or one of its affiliates or
//   subsidiaries, has supplied this software to you under terms of a
namespace AdventOfCode2020.Day10
{
    using System;

    public class DifferenceCounter
    {
        private int oneDifferenceCount = 0;
        private int threeDifferenceCount = 0;

        public DifferenceCounter(int firstJoltage)
        {
            CountDifference(0, firstJoltage);
        }

        public void CountDifference(int lower, int higher)
        {
            switch (higher - lower)
            {
                case 1: oneDifferenceCount++;
                    break;
                case 3:
                    threeDifferenceCount++;
                    break;
                default:
                    throw new ArgumentException($"Argument difference is not acceptable. Arguments: {lower}, {higher}");
            }
        }

        public int Result => oneDifferenceCount * threeDifferenceCount;
    }
}

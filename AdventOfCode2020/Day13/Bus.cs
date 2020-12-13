using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day13
{
    internal class Bus
    {
        private readonly decimal id;
        private readonly decimal expectedRemainder;

        public Bus(int id, int position)
        {
            this.id = id;
            expectedRemainder = (id - position) % id;
        }

        public decimal Id => id;

        public bool IsInPlace(decimal timestamp)
        {
            return timestamp % id == expectedRemainder;
        }

        public decimal CalculateAiXMiXNi(decimal M)
        {
            var Ai = expectedRemainder;
            decimal Mi = M / id;
            (decimal ni, decimal Ni) = DoExtendedEuclideianAlgorithm(id, Mi);
            return Ai * Ni * Mi;
        }

        private (decimal ni, decimal Ni) DoExtendedEuclideianAlgorithm(decimal mi, decimal Mi)
        {
            int n = 0;
            List<decimal> x = new List<decimal> { 1, 0 };
            List<decimal> y = new List<decimal> { 0, 1 };
            List<decimal> r = new List<decimal> { mi, Mi };
            List<decimal> q = new List<decimal> { 0 };
            while (r[n+1] != 0)
            {
                q.Add(Math.Floor(r[n] / r[n + 1]));
                r.Add(r[n] % r[n + 1]);
                x.Add(x[n] - x[n+1] * q[n+1]);
                y.Add(y[n] - y[n+1] * q[n+1]);
                n++;
            }
            return (x[n], y[n]);
        }
    }
}
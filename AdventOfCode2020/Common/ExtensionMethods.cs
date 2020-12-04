using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Common
{
    public static class ExtensionMethods
    {
        public static bool IsBetween(this int x, int min, int max) => min <= x && x <= max; 
    }
}

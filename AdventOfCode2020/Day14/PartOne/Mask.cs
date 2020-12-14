using System;
using System.Text;

namespace AdventOfCode2020.Day14.PartOne
{
    internal class Mask
    {
        private readonly string maskValue;

        public Mask(string maskValue)
        {
            this.maskValue = maskValue;
        }

        internal long GetMaskedValue(long value)
        {
            var binaryValue = Convert.ToString(value, 2).PadLeft(maskValue.Length, '0');
            StringBuilder maskedValue = new StringBuilder();
            for (int i = 0; i < maskValue.Length; i++)
            {
                if (maskValue[i] == 'X')
                {
                    maskedValue.Append(binaryValue[i]);
                }
                else
                {
                    maskedValue.Append(maskValue[i]);
                }
            }
            return Convert.ToInt64(maskedValue.ToString(), 2);
        }
    }
}
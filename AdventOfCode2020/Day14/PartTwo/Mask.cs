namespace AdventOfCode2020.Day14.PartTwo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Mask
    {
        private readonly string maskValue;

        public Mask(string maskValue)
        {
            this.maskValue = maskValue;
        }

        internal IEnumerable<long> GetMaskedValues(long value)
        {
            var binaryValue = Convert.ToString(value, 2).PadLeft(maskValue.Length, '0');
            StringBuilder maskedValue = new StringBuilder();
            var floatingValueVariations = new HashSet<long> { 0 };
            var maxValue = 1L << (maskValue.Length - 1);
            for (int i = 0; i < maskValue.Length; i++)
            {
                if (maskValue[i] == '0')
                {
                    maskedValue.Append(binaryValue[i]);
                }
                else if (maskValue[i] == '1')
                {
                    maskedValue.Append('1');
                }
                else
                {
                    maskedValue.Append('0');
                    var newFloatingBitValue = maxValue >> i;
                    var newFloatingValueVariations = new HashSet<long>();
                    foreach (var floatingValueVariation in floatingValueVariations)
                    {
                        newFloatingValueVariations.Add(floatingValueVariation + newFloatingBitValue);
                    }
                    floatingValueVariations.UnionWith(newFloatingValueVariations);
                }
            }

            var baseValue = Convert.ToInt64(maskedValue.ToString(), 2);

            foreach (var floatingBitValueVariation in floatingValueVariations)
            {
                yield return baseValue + floatingBitValueVariation;
            }
        }
    }
}

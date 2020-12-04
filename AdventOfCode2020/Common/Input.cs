using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Common
{
    public class Input<T> : IEnumerable<T>
    {
        private readonly string day;
        private readonly Func<string, T> convert;

        public Input(string day, Func<string, T> convert)
        {
            this.day = day;
            this.convert = convert;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var fileStream = new FileStream(@$"Day{day}/Input.txt", FileMode.Open, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                yield return convert(line);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

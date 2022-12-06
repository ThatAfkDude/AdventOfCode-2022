using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Day06
{
    public class Day6 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"Inputs\Day06.txt");
            int res = 0;
            foreach (var entry in input)
            {
                for(int i = 0; i< entry.Length; i++)
                {
                    var span = entry.AsSpan(i, 4);
                    if(span.ToArray().ToList().Distinct().Count() == 4)
                    {
                        res = i + 4;
                        break;
                    }
                }
            }

            Console.WriteLine(res);
        }

        public void Solve2()
        {
            var input = InputReader.ReadStringList(@"Inputs\Day06.txt");
            int res = 0;
            var uniqueNumber = 14;
            foreach (var entry in input)
            {
                for (int i = 0; i < entry.Length; i++)
                {
                    var span = entry.AsSpan(i, uniqueNumber);
                    if (span.ToArray().ToList().Distinct().Count() == uniqueNumber)
                    {
                        res = i + uniqueNumber;
                        break;
                    }
                }
            }

            Console.WriteLine(res);
        }
    }
}

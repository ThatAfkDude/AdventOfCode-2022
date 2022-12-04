using AdventOfCode.Import;
using System;
using System.Linq;

namespace AdventOfCode.Solutions.Day01
{
    public class Day1 : ISolver
    {
        public void Solve()
        {
            Console.WriteLine(SpecialInputReader.ReadListOfIntListSeperatedByEmptyLine(@"Inputs\Day01.txt").Select(x => x.Sum()).Max());
        }

        public void Solve2()
        {
            Console.WriteLine(SpecialInputReader.ReadListOfIntListSeperatedByEmptyLine(@"Inputs\Day01.txt").Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum());
        }
    }
}

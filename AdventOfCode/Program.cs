
using AdventOfCode.Solutions.Day01;
using AdventOfCode.Solutions.Day02;
using AdventOfCode.Solutions.Day03;
using AdventOfCode.Solutions.Day04;
using AdventOfCode.Solutions.Day05;
using AdventOfCode.Solutions.Day06;
using AdventOfCode.Solutions.Day07;
using AdventOfCode.Solutions.Day08;
using AdventOfCode.Solutions.Day09;
using AdventOfCode.Solutions.Day10;
using AdventOfCode.Solutions.Day11;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = -1;
            var solveAll = false;


            var solvers = new List<ISolver>
            {
                new Day1(),
                new Day2(),
                new Day3(),
                new Day4(),
                new Day5(),
                new Day6(),
                new Day7(),
                new Day8(),
                new Day9(),
                new Day10(),
                new Day11()
            };


            if (solveAll)
            {
                foreach(var solver in solvers)
                {
                    Solve(solver);
                }
            }
            else
            {
                day = day == -1 ? solvers.Count : day;

                Solve(solvers[day-1]);
            }
           
            Console.Read();
        }

        private static void Solve(ISolver solver)
        {
            Console.WriteLine();
            Console.WriteLine($"{solver.GetType().Name}");
            Console.WriteLine($"---------------------------------");
            Console.WriteLine($"Solution 1:");
            solver.Solve();
            Console.WriteLine($"---------------------------------");
            Console.WriteLine($"Solution 2:");
            solver.Solve2();
            Console.WriteLine($"---------------------------------");
            Console.WriteLine();
        }
    }
}


using AdventOfCode.Solutions.Day01;
using AdventOfCode.Solutions.Day02;
using AdventOfCode.Solutions.Day03;
using AdventOfCode.Solutions.Day04;
using AdventOfCode.Solutions.Day05;
using AdventOfCode.Solutions.Day06;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = -1;
            var solveAll = true;


            var solvers = new List<ISolver>();
            solvers.Add(new Day1());
            solvers.Add(new Day2());
            solvers.Add(new Day3());
            solvers.Add(new Day4());
            solvers.Add(new Day5());
            solvers.Add(new Day6());


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

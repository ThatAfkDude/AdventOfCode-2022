using AdventOfCode._2023.Solutions;
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
                new Day01(),
                new Day02(),
                new Day03(),
                new Day04(),
                new Day05(),

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

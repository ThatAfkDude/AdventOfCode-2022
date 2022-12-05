using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Day05
{
    public class Day5 : ISolver
    {
        public void Solve()
        {
            var input = SpecialInputReader.ReadDay5Input(@"Inputs\Day05.txt");
            var crates = input.CrateStacks;

            var instructions = input.Instructions;

            foreach (var instruction in instructions)
            {
                for(int i = 0; i < instruction.Number; i++)
                {
                    crates[instruction.Destination - 1].Push(crates[instruction.Start - 1].Pop());
                }
            }

            var result = string.Empty;
            foreach(var crate in crates)
            {
                result += crate.Pop();
            }

            Console.WriteLine(result);
        }

        public void Solve2()
        {
            var input = SpecialInputReader.ReadDay5Input(@"Inputs\Day05.txt");
            var crates = input.CrateStacks;

            var instructions = input.Instructions;
            var tempStack = new Stack<char>();

            foreach (var instruction in instructions)
            {
                for (int i = 0; i < instruction.Number; i++)
                {
                     tempStack.Push(crates[instruction.Start - 1].Pop());
                }
                for (int i = 0; i < instruction.Number; i++)
                {
                    crates[instruction.Destination - 1].Push(tempStack.Pop());
                }
            }

            var result = string.Empty;
            foreach (var crate in crates)
            {
                result += crate.Pop();
            }

            Console.WriteLine(result);
        }
    }
}

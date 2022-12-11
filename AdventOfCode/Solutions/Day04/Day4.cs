using AdventOfCode.Import;
using System;

namespace AdventOfCode.Solutions.Day04
{
    public class Day4 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"Inputs\Day04.txt");
            var count = 0;
            foreach (var item in input)
            {
                int firstLower, firstUpper, secondLower, secondUpper;
                ProcessInput(item, out firstLower, out firstUpper, out secondLower, out secondUpper);

                if ((firstLower <= secondLower && firstUpper >= secondUpper) || (firstLower >= secondLower && firstUpper <= secondUpper))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        public void Solve2()
        {
            var input = InputReader.ReadStringList(@"Inputs\Day04.txt");
            var count = 0;
            foreach (var item in input)
            {
                int firstLower, firstUpper, secondLower, secondUpper;
                ProcessInput(item, out firstLower, out firstUpper, out secondLower, out secondUpper);

                if ((firstLower <= secondLower && firstUpper >= secondLower)
                    || (firstLower >= secondLower && secondUpper >= firstLower))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        } 
        
        private static void ProcessInput(string item, out int firstLower, out int firstUpper, out int secondLower, out int secondUpper)
        {
            var firstRange = item.Split(',')[0];
            firstLower = int.Parse(firstRange.Split('-')[0]);
            firstUpper = int.Parse(firstRange.Split('-')[1]);
            var secondRange = item.Split(',')[1];
            secondLower = int.Parse(secondRange.Split('-')[0]);
            secondUpper = int.Parse(secondRange.Split('-')[1]);
        }
    }
}

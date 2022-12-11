using AdventOfCode.Import;
using System;

namespace AdventOfCode.Solutions.Day03
{
    public class Day3 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"Inputs\Day03.txt");
            var sum = 0;
            foreach (var item in input)
            {
                var halfLength = item.Length / 2;
                var firstHalf = item.AsSpan(0, halfLength);
                var secondHalf = item.AsSpan(halfLength);

                foreach (var letter in firstHalf.ToArray())
                {
                    if (secondHalf.Contains(letter))
                    {
                        sum += letter > 95 ? letter - 'a' + 1 : letter - 'A' + 27;
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }

        public void Solve2()
        {
            var allLetters = new char[] { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H', 'i', 'I', 'j', 'J', 'k', 'K', 'l', 'L', 'm', 'M', 'n', 'N', 'o', 'O', 'p', 'P', 'q', 'Q', 'r', 'R', 's', 'S', 't', 'T', 'u', 'U', 'v', 'V', 'w', 'W', 'x', 'X', 'y', 'Y', 'z', 'Z' };

            var input = InputReader.ReadStringList(@"Inputs\Day03.txt");
            var sum = 0;

            for (int i = 0; i < input.Count; i += 3)
            {
                foreach (var letter in allLetters)
                {
                    if (input[i + 0].Contains(letter) &&
                        input[i + 1].Contains(letter) &&
                        input[i + 2].Contains(letter))
                    {
                        sum += letter > 95 ? letter - 'a' + 1 : letter - 'A' + 27;
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}

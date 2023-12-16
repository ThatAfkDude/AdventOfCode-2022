using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Solutions
{
    internal class Day01 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day01.txt");

            var zero = (byte)'0';
            var nine = (byte)'9';

            var res = 0;
            foreach (var item in input)
            {
                var chars = item.First(x => ((byte)x) >= zero && ((byte)x) <= nine) + "" + item.Last(x => ((byte)x) >= zero && ((byte)x) <= nine);
                res += int.Parse(chars);
            }
            Console.WriteLine(res);
        }

        public void Solve2()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day01.txt");

            var zero = (byte)'0';
            var nine = (byte)'9';

            var wordNumbers = new Dictionary<string, string>
            {
                { "zero", "zero0zero" },
                { "one", "one1one" },
                { "two", "two2two" },
                { "three", "three3three" },
                { "four", "four4four" },
                { "five", "five5five" },
                { "six", "six6six" },
                { "seven", "seven7seven" },
                { "eight", "eight8eight" },
                { "nine", "nine9nine" }
            };

            var res = 0;
            foreach (var item in input)
            {
                var newItem = item;
                foreach (var wordNumber in wordNumbers)
                {
                    newItem = newItem.Replace(wordNumber.Key, wordNumber.Value);
                }
                var chars = newItem.First(x => ((byte)x) >= zero && ((byte)x) <= nine) + "" + newItem.Last(x => ((byte)x) >= zero && ((byte)x) <= nine);
                res += int.Parse(chars);
            }
            Console.WriteLine(res);
        }
    }
}

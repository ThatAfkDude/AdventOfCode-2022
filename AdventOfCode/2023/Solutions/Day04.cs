using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Solutions
{
    internal class Day04 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day04.txt");
            var result = 0;
            foreach (var item in input)
            {
                var numbers = item.Split(':')[1].Trim().Split('|');

                var winners = numbers[0].Trim().Replace("  "," ").Split(" ");
                var testNumbers = numbers[1].Trim().Replace("  ", " ").Split(" ");

                var score = 0;
                foreach (var testNumber in testNumbers)
                {
                    if(winners.Any(x => int.Parse(x) == int.Parse(testNumber)))
                    {
                        score++;
                    }
                }
                result += GetScore(score);
            }

            Console.WriteLine(result);
        }

        private int GetScore(int score)
        {
            if (score == 0 || score == 1)
            {
                return score;
            }
           return (int)Math.Pow(2, score - 1);
        }

        public void Solve2()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day04.txt");
            var list = new List<(int id, int score, int number)>();
            var index = 1;
            foreach (var item in input)
            {
                var numbers = item.Split(':')[1].Trim().Split('|');

                var winners = numbers[0].Trim().Replace("  ", " ").Split(" ");
                var testNumbers = numbers[1].Trim().Replace("  ", " ").Split(" ");

                var score = 0;
                foreach (var testNumber in testNumbers)
                {
                    if (winners.Any(x => int.Parse(x) == int.Parse(testNumber)))
                    {
                        score++;
                    }
                }
                list.Add((index, score, 1));
                index++;
            }

            var sum = 0;
            var length = list.Count;
            for (int i = 0; i < length; i++)
            {
                for (int k = 0; k < list[i].number; k++)
                { 
                    for (int j = 0; j < list[i].score; j++) 
                    {
                        var lilIndex = i + 1 + j;
                        if (i+1+j < length)
                        {
                            list[lilIndex] = (list[lilIndex].id, list[lilIndex].score, list[lilIndex].number + 1);
                        }
                    }
                    sum++;
                }
            }

            Console.WriteLine(sum);
        }
    }
}

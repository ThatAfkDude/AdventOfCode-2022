using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2023.Solutions
{
    internal class Day02 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day02.txt");

            var colours = new Dictionary<string, int>
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            var idSum = 0;

            foreach (var game in input)
            { 
                bool isPossible = true;
                var idAndGames = game.Split(':');
                var id = int.Parse(idAndGames[0].Replace("Game ", string.Empty));
                var rounds = idAndGames[1].Split(";");

                foreach (var round in rounds)
                {
                    var pieces = round.Split(",");
                    foreach (var piece in pieces)
                    {
                        var res = piece.Split(" ");
                        if (colours.GetValueOrDefault(res[2]) < int.Parse(res[1]))
                        {
                            isPossible = false;
                        }
                    }
                }

                if (isPossible)
                {
                    idSum += id;
                }
            }

            Console.WriteLine(idSum);
        }

        public void Solve2()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day02.txt");

            var colours = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 1 },
                { "blue", 2 }
            };

            var sum = 0;

            foreach (var game in input)
            {
                var resArray = new[] { 0, 0, 0 };

                var idAndGames = game.Split(':');
                var id = int.Parse(idAndGames[0].Replace("Game ", string.Empty));
                var rounds = idAndGames[1].Split(";");

                foreach (var round in rounds)
                {
                    var pieces = round.Split(",");
                    foreach (var piece in pieces)
                    {
                        var res = piece.Split(" ");
                        if (resArray[colours.GetValueOrDefault(res[2])] < int.Parse(res[1]))
                        {
                            resArray[colours.GetValueOrDefault(res[2])] = int.Parse(res[1]);
                        }
                    }
                }

                var power = resArray.Aggregate(1, (a, b) => a * b);
                sum += power;
            }

            Console.WriteLine(sum);
        }
    }
}

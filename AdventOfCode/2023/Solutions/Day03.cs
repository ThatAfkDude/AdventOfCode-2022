using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Solutions
{
    internal class Day03 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day03.txt");
            var numbers = new[] {'0','1','2','3','4','5','6','7','8','9'};
            var index = 0;
            var symbols = new List<(int x,int y)>();
            var numberRes = new List<(int x, int y, int number, int length)>();
            foreach (var line in input)
            {
                var length = line.Length;
                var currentNumber = string.Empty;
                var currentNumberPosition = 0;

                //spot number
                for(var i = 0; i < length; i++)
                {
                    var currentC = line[i];

                    if (currentC == '.') 
                    {
                        if (!string.IsNullOrEmpty(currentNumber))
                        {
                            numberRes.Add((currentNumberPosition, index,int.Parse(currentNumber), currentNumber.Length));
                            currentNumber = string.Empty;
                        }
                    }
                    else if (numbers.Contains(currentC)) 
                    {
                        if (string.IsNullOrEmpty(currentNumber))
                        {
                            currentNumberPosition = i;
                        }
                        currentNumber += currentC;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(currentNumber))
                        {
                            numberRes.Add((currentNumberPosition, index, int.Parse(currentNumber), currentNumber.Length));
                            currentNumber = string.Empty;
                        }
                        symbols.Add((i,index));
                    }
                }

                //decide if its connected
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    numberRes.Add((currentNumberPosition, index, int.Parse(currentNumber), currentNumber.Length));
                    currentNumber = string.Empty;
                }
                index++;
            }
            var sum = 0;
            foreach (var entry in numberRes)
            {
                var xMin = entry.x - 1;
                var xMax = entry.x + entry.length;

                var yMin = entry.y - 1;
                var yMax = entry.y + 1;

                if (symbols.Any(x => (x.x >= xMin && x.x <= xMax)
                                  && (x.y >= yMin && x.y <= yMax)))
                {
                    sum += entry.number;
                } 
            }

            Console.WriteLine(sum);
        }

        public void Solve2()
        {
            var input = InputReader.ReadStringList(@"2023\Inputs\Day03.txt");
            var numbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var index = 0;
            var symbols = new List<(int x, int y, char symbol)>();
            var numberRes = new List<(int x, int y, int number, int length)>();
            foreach (var line in input)
            {
                var length = line.Length;
                var currentNumber = string.Empty;
                var currentNumberPosition = 0;

                //spot number
                for (var i = 0; i < length; i++)
                {
                    var currentC = line[i];

                    if (currentC == '.')
                    {
                        if (!string.IsNullOrEmpty(currentNumber))
                        {
                            numberRes.Add((currentNumberPosition, index, int.Parse(currentNumber), currentNumber.Length));
                            currentNumber = string.Empty;
                        }
                    }
                    else if (numbers.Contains(currentC))
                    {
                        if (string.IsNullOrEmpty(currentNumber))
                        {
                            currentNumberPosition = i;
                        }
                        currentNumber += currentC;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(currentNumber))
                        {
                            numberRes.Add((currentNumberPosition, index, int.Parse(currentNumber), currentNumber.Length));
                            currentNumber = string.Empty;
                        }
                        symbols.Add((i, index, currentC));
                    }
                }

                //decide if its connected
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    numberRes.Add((currentNumberPosition, index, int.Parse(currentNumber), currentNumber.Length));
                    currentNumber = string.Empty;
                }
                index++;
            }
            var sum = 0;

            foreach (var symbol in symbols)
            {
                if(symbol.symbol == '*')
                {
                    var res = numberRes.Where(x => Check(symbol,x));
                   if(res.Count() == 2)
                    {
                        sum += res.First().number * res.Last().number;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        private static bool Check((int x, int y, char symbol) symbol,(int x, int y, int number, int length) entry)
        {
            var xMin = entry.x - 1;
            var xMax = entry.x + entry.length;

            var yMin = entry.y - 1;
            var yMax = entry.y + 1;

            return (symbol.x >= xMin && symbol.x <= xMax)
                              && (symbol.y >= yMin && symbol.y <= yMax);
        }
    }
}

using AdventOfCode.Import;
using System;
using System.Diagnostics.Metrics;


namespace AdventOfCode.Solutions.Day08
{
    internal class Day8 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.Read2DIntArray(@"Inputs\Day08.txt");

            var xMax = input.GetLength(0);
            var yMax = input.GetLength(1);

            var visible = 0;

            for ( var i = 1; i < xMax-1; i++)
            {
                for( var j = 1; j < yMax-1; j++)
                {
                    var currentValue = (int)input.GetValue(i, j);
                    var topMax = GetMaxFor(0, i - 1, j, j, input);
                    var botMax = GetMaxFor(i + 1, xMax-1 , j, j, input);
                    var leftMax = GetMaxFor(i, i, 0, j - 1 , input);
                    var rightMax = GetMaxFor(i, i, j + 1, yMax - 1 , input);

                    if(currentValue > topMax || currentValue > botMax || currentValue > rightMax || currentValue > leftMax)
                    {
                        visible++;
                    }
                }
            }

            visible += xMax + xMax + yMax + yMax - 4;

            Console.WriteLine(visible);
        }

        public void Solve2()
        {
            var input = InputReader.Read2DIntArray(@"Inputs\Day08.txt");

            var xMax = input.GetLength(0);
            var yMax = input.GetLength(1);

            var topRes = 0;

            for (var i = 1; i < xMax - 1; i++)
            {
                for (var j = 1; j < yMax - 1; j++)
                {
                    var currentValue = (int)input.GetValue(i, j);
                    var topMax = GetSceneScoreL(0, i - 1, j, j, input, currentValue);
                    var botMax = GetSceneScore(i + 1, xMax - 1, j, j, input, currentValue);
                    var leftMax = GetSceneScoreL(i, i, 0, j - 1, input, currentValue);
                    var rightMax = GetSceneScore(i, i, j + 1, yMax - 1, input, currentValue);

                    var res = topMax * botMax * leftMax * rightMax;
                   
                    topRes = topRes > res ? topRes : res;
                }
            }
            Console.WriteLine(topRes);
        }

        private int GetMaxFor(int x, int xM, int y, int yM, int[,] input)
        {
            var max = 0;
            for (var i = x; i <= xM; i++)
            {
                for (var j = y; j <= yM; j++)
                {

                    int value = (int)input.GetValue(i, j);
                    max = value > max ? value : max;
                }
            }

            return max;
        }

        private int GetSceneScore(int x, int xM, int y, int yM, int[,] input, int cV)
        {
            var counter = 0;
            for (var i = x; i <= xM; i++)
            {
                for (var j = y; j <= yM; j++)
                {
                    counter++;
                    if(cV <= (int)input.GetValue(i, j))
                    {
                        return counter;
                    }
                }
            }

            return counter;
        }

        private int GetSceneScoreL(int x, int xM, int y, int yM, int[,] input, int cV)
        {
            var counter = 0;
            for (var i = xM; i >= x; i--)
            {
                for (var j = yM; j >= y; j--)
                {
                    counter++;
                    if (cV <= (int)input.GetValue(i, j))
                    {
                        return counter;
                    }
                }
            }

            return counter;
        }
    }
}

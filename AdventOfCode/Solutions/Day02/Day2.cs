using AdventOfCode.Import;
using System;

namespace AdventOfCode.Solutions.Day02
{
    public class Day2 : ISolver
    {
        public void Solve()
        {
            // x = rock, y = paper, z = scissors
            // a = rock, b = paper, c = scissors
            var input = InputReader.ReadCharCharTuple(@"Inputs\Day02.txt",' ');

            var sum = 0;
            foreach (var item in input)
            {
                var me = item.Item2 - 23 - 'A' + 1;
                var they = item.Item1 - 'A' + 1;

                var res = they - me;
                if(res == 2 || res == -1)
                {
                    sum += 6;
                }
                if(res == 0)
                {
                    sum += 3;
                }
                sum += me;
            }
            Console.WriteLine(sum);
        }

        public void Solve2()
        {
            var input = InputReader.ReadCharCharTuple(@"Inputs\Day02.txt", ' ');

            var sum = 0;
            foreach (var item in input)
            {
                var enemyItem = item.Item1 - 'A' + 1;
                var me = item.Item2 - 23 - 'A' + 1;
                sum += GetScore(enemyItem, me);
            }
            Console.WriteLine(sum);
        }
        
        public static int GetScore(int enemyItem, int me)
        {
            var score = 0;
            score += (me - 1) * 3;
            score += ((enemyItem - 1) + 2 + (me - 1)) % 3 + 1; ;
            return score;
        }
    }
}

using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Solutions.Day11
{
    internal class Day11 : ISolver
    {
        public void Solve()
        {
            var input = SpecialInputReader.GetMonkeyListFromFile(@"Inputs\Day11.txt");

            var roundNumber = 20;
            for(var j = 0; j < roundNumber; j++)
            { 
                for(int i = 0; i < input.Count(); i++)
                {
                    var res = input[i].TakeTurn();
                    foreach(var result in res)
                    {
                        input[result.monkeyIndex].AddItem(result.item);
                    }
                }
            }
            var inspectCounter = 1;
            var topTwo = input.OrderByDescending(x => x.InspectCounter).Take(2);
            foreach(var monkey in topTwo)
            {
                inspectCounter *= monkey.InspectCounter;
            }
            Console.WriteLine(inspectCounter.ToString());
        }

        public void Solve2()
        {
            var input = SpecialInputReader.GetMonkeyListFromFile(@"Inputs\Day11.txt");
            var roundNumber = 10000;
            var allDivisorsMultiplied = 1;
            foreach (var monkey in input)
            {
                allDivisorsMultiplied *= monkey.Divisor;
            }
            for (var j = 0; j < roundNumber; j++)
            {
                for (int i = 0; i < input.Count(); i++)
                {
                    var res = input[i].TakeTurn(true, allDivisorsMultiplied);
                    foreach (var result in res)
                    {
                        input[result.monkeyIndex].AddItem(result.item);
                    }
                }
            }
            BigInteger inspectCounter = 1;
            var topTwo = input.OrderByDescending(x => x.InspectCounter).Take(2);
            foreach (var monkey in topTwo)
            {
                inspectCounter *= monkey.InspectCounter;
            }
            Console.WriteLine(inspectCounter.ToString());
        }
    }

    public class Monkey
    {
        private Queue<BigInteger> queue = new Queue<BigInteger>();
        public int TrueMonkeyIndex { get; set; }
        public int FalseMonkeyIndex { get; set; }
        public int Divisor { get; set; }
        public int Factor { get; set; }
        public char Operation { get; set; }
        public int InspectCounter { get; set; }

        public void AddItem(BigInteger item)
        {
            queue.Enqueue(item);
        }

        public List<(int monkeyIndex , BigInteger item)> TakeTurn(bool veryWorried = false, int bigDivisor = 1)
        {
            var returnList = new List<(int monkeyIndex , BigInteger item)> ();
            while(queue.Count > 0)
            {
                InspectCounter++;
                //inspect + relax
                var item = queue.Dequeue();

                // operation
                if (Operation == 'P')
                {
                    item *= item;
                }
                if (Operation == '*')
                {
                    item *= Factor;
                }
                if (Operation == '+')
                {
                    item += Factor;
                }

                // relax
                if (!veryWorried)
                {
                    item /= 3;
                }
                else
                {
                    item = item % bigDivisor;
                }

                if (item % Divisor == 0)
                {
                    returnList.Add((TrueMonkeyIndex, item));
                }
                else
                {
                    returnList.Add((FalseMonkeyIndex, item));
                }
            }
            return returnList;
        }
    }
}

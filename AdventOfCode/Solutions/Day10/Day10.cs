using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Day10
{
    internal class Day10 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringIntTuple(@"Inputs\Day10.txt");
            var cycle = 0;
            var register = 1;
            var res = new List<int>();

            foreach (var inputItem in input)
            {
                Execution execution;
                if (inputItem.Item2 == 0)
                {
                    execution = new Execution() { Value = inputItem.Item2, Timer = 1 };
                }
                else
                {
                    execution = new Execution() { Value = inputItem.Item2, Timer = 2 };
                }

                for (var i = 0; i < execution.Timer; i++)
                {
                    cycle++;
                    if ((cycle +20) % 40 == 0)
                    {
                        res.Add(cycle * register);
                    }
                }
                register += execution.Value;
            }
            Console.WriteLine(res.Sum());
        } 

        public void Solve2()
        {
            var input = InputReader.ReadStringIntTuple(@"Inputs\Day10.txt");
            var cycle = 0;
            var register = 1;
            var image = new List<string>() { "", "", "", "", "", "" };
            var row = 0;

            foreach (var inputItem in input)
            {
                Execution execution;
                if (inputItem.Item2 == 0)
                {
                    execution = new Execution() { Value = inputItem.Item2, Timer = 1 };
                }
                else
                {
                    execution = new Execution() { Value = inputItem.Item2, Timer = 2 };
                }

                for (var i = 0; i < execution.Timer; i++)
                {
                    var c = cycle % 40;
                    if(register -1 <= c && register + 1 >= c)
                    {
                        image[row] += "#";
                    }
                    else
                    {
                        image[row] += ".";
                    }
                    cycle++;

                    if ((cycle) % 40 == 0)
                    {
                        row++;
                    }
                }
                register += execution.Value;
            }
            Console.WriteLine();
            foreach (var line in image)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }

    internal class Execution
    {
        internal int Timer { get; set; }
        internal int Value { get; set; }  
    }

    /*
     initial attempt
     var input = InputReader.ReadStringIntTuple(@"Inputs\Day10E.txt");

            var cycle = 0;
            var register = 1;
            var executionList = new List<Execution>();
            var res = new List<int>();
            var x = new List<int>();

            while (true)
            {

                //Start -> read next command
                if (input.Count() > cycle)
                {
                    executionList.Add(new Execution() { Value = input[cycle].Item2, Timer = 2 });
                }

                //execution
                for (var i = 0; i < executionList.Count(); i++)
                {
                    executionList[i].Timer--;
                }

                if (cycle % 20 == 0)
                {
                    res.Add(cycle * register);
                }

                //end of cycle
                for (var i = 0; i < executionList.Count(); i++)
                {
                    if (executionList[i].Timer == 0)
                    {
                        register += executionList[i].Value;
                        x.Add(register);
                    }
                }


                //cleanup
                executionList = executionList.Where(x => x.Timer > 0).ToList();


                cycle++;


                if (executionList.Count() == 0 && input.Count() < cycle)
                {
                    break;
                }
            }
    */
}

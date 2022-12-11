using AdventOfCode.Solutions.Day11;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Import
{
    public static class SpecialInputReader
    {
        //2022 Day 1
        public static List<List<double>> ReadListOfIntListSeperatedByEmptyLine(string path)
        {
            var bigList = new List<List<double>>();
            var list = new List<double>();

            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    bigList.Add(list);
                    list = new List<double>();
                }
                else
                {
                    list.Add(double.Parse(line));
                }
            }
            bigList.Add(list);
            return bigList;
        }

        public static (List<Stack<char>> CrateStacks,List<(int Number, int Start, int Destination)> Instructions) ReadDay5Input(string path)
        {
            var stackList = new List<Stack<char>>();
            var instructionsList = new List<(int, int, int)>();

            string[] lines = System.IO.File.ReadAllLines(path);

            var numbers = lines.FirstOrDefault(x => x.StartsWith(" 1"));
            var stackNumber = int.Parse(numbers.Trim().Split(" ").LastOrDefault());

            for(var i = 0; i < stackNumber; i++)
            {
                stackList.Add(new Stack<char>());
            }

            foreach (string line in lines)
            {
                if (line.Contains("["))
                {
                    var index = 1;
                    for(int i = 0; i < stackNumber; i++)
                    {
                        if(line[index] != ' ')
                        {
                            stackList[i].Push(line[index]);
                        }
                        index += 4;
                    }
                }
                if (line.Contains("move"))
                {
                    var split = line.Split(" ");
                    instructionsList.Add((int.Parse(split[1]), int.Parse(split[3]), int.Parse(split[5])));
                }
            }

            var revertedStackList = new List<Stack<char>>();
            foreach (var stack in stackList)
            {
                revertedStackList.Add(new Stack<char>(stack));
            }

            return (revertedStackList, instructionsList);
        }

        public static List<Monkey> GetMonkeyListFromFile(string path)
        {
            var monkeyList = new List<Monkey>();

            string[] lines = System.IO.File.ReadAllLines(path);

            for(int i = 0; i < lines.Length; i += 7)
            {
                var newMonkey = new Monkey()
                {
                    Divisor = int.Parse(lines[i + 3].Split("by ")[1]),
                    TrueMonkeyIndex = int.Parse(lines[i + 4].Split("monkey ")[1]),
                    FalseMonkeyIndex = int.Parse(lines[i + 5].Split("monkey ")[1]),
                };

                var items = lines[i + 1].Split(":")[1].Split(",");
                foreach (var item in items)
                {
                    newMonkey.AddItem(int.Parse(item.Trim()));
                }

                var operation = lines[i + 2].Split("new = old ")[1].Split(" ");
                if (operation[1] == "old")
                {
                    newMonkey.Operation = 'P';
                    newMonkey.Factor = 0;
                }
                else
                {
                    newMonkey.Operation = operation[0][0];
                    newMonkey.Factor = int.Parse(operation[1]);
                }
                monkeyList.Add(newMonkey);
            }
            return monkeyList;
        }
    }
}

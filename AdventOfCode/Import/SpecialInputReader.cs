using System.Collections.Generic;

namespace AdventOfCode.Import
{
    public static class SpecialInputReader
    {
        //input reader that are not reusable
        /*
        //2021 Day4-1
        public static (List<int>, List<BingoField>) ReadBingoFields(string path)
        {
            var numbers = new List<int>();
            var bingoFields = new List<BingoField>();
            string[] lines = System.IO.File.ReadAllLines(path);
            var numbersAsChars = lines[0].Split(',');
            foreach (var item in numbersAsChars)
            {
                numbers.Add(int.Parse(item));
            }
            for (int i = 2; i < lines.Length; i += 6)
            {
                var bingoFieldNumbers = new List<int>();

                for (int j = 0; j < 5; j++)
                {
                    var numbersAsCharsInLine = lines[i + j].Split(' ');
                    foreach (var item in numbersAsCharsInLine)
                    {
                        if (item != "")
                        {
                            bingoFieldNumbers.Add(int.Parse(item));
                        }
                    }
                }
                bingoFields.Add(new BingoField(bingoFieldNumbers));
            }
            return (numbers, bingoFields);
        }

        //2021-Day5-1
        public static List<Line> ReadLineKoords(string path)
        {
            var koords = new List<Line>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var koordPair = line.Replace(" -> ", " ").Split(" ");
                var startString = koordPair[0].Split(",");
                var start = new Koordinate()
                {
                    X = int.Parse(startString[0]),
                    Y = int.Parse(startString[1])
                };
                var endString = koordPair[1].Split(",");
                var end = new Koordinate()
                {
                    X = int.Parse(endString[0]),
                    Y = int.Parse(endString[1])
                };
                koords.Add(new Line()
                {
                    End = end,
                    Start = start
                });
            }
            return koords;
        }

        //2021 Day8-1
        public static List<SignalsOutputs> ReadSignalsAndOutputs(string path,bool round)
        {
            var input = new List<SignalsOutputs>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var elements = line.Replace(" -> ", " ").Split("|");
                var inputs = elements[0].Trim().Split(" ");
                var outputs  = elements[1].Trim().Split(" ");
                input.Add(new SignalsOutputs(inputs, outputs, round));
            }
            return input;
        }*/

        //2022 Day 1
        public static List<List<double>> ReadListOfIntListSeperatedByEmptyLine(string path)
        {
            var bigList = new List<List<double>>();
            
            string[] lines = System.IO.File.ReadAllLines(path);

            var list = new List<double>();

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
    }
}

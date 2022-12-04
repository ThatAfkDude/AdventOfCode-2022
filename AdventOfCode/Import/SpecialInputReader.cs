using System.Collections.Generic;

namespace AdventOfCode.Import
{
    public static class SpecialInputReader
    {
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

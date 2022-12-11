using System.Collections.Generic;

namespace AdventOfCode.Import
{
    public static class InputReader
    {
        //inputs readers that might be reusable
        public static List<int> ReadIntList(string path)
        {
            var list = new List<int>();

            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                list.Add(int.Parse(line));
            }
            return list;
        }

        public static List<int> ReadIntListCommaSeperatedSingleDigitSignleLine(string path)
        {
            var list = new List<int>();

            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (char number in lines[0].Replace(",",string.Empty))
            {
                list.Add(int.Parse(number.ToString()));
            }
            return list;
        }

        public static List<int> ReadIntListCommaSeperatedMultiDigitsSignleLine(string path)
        {
            var list = new List<int>();

            string[] lines = System.IO.File.ReadAllLines(path);

            var numbers = lines[0].Split(",");

            foreach (string number in numbers)
            {
                list.Add(int.Parse(number.ToString()));
            }
            return list;
        }

        public static List<string> ReadStringList(string path)
        {
            var list = new List<string>();

            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                list.Add(line);
            }
            return list;
        }


        public static List<(string, int)> ReadStringIntTuple(string path)
        {
            var list = new List<(string, int)>();

            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                var entry = line.Split(new char[] { ' ' });
                if(entry.Length == 2)
                {
                    list.Add((entry[0], int.Parse(entry[1])));
                }
                else
                {
                    list.Add((entry[0], 0));
                } 
            }
            return list;
        }

        public static List<(string, string)> ReadStringStringTuple(string path, char seperator)
        {
            var list = new List<(string, string)>();

            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                var entry = line.Split(new char[] { seperator });
                list.Add((entry[0], entry[1]));
            }
            return list;
        }

        public static List<(char, char)> ReadCharCharTuple(string path, char seperator)
        {
            var list = new List<(char, char)>();

            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                var entry = line.Split(new char[] { seperator });
                list.Add((entry[0].ToCharArray()[0], entry[1].ToCharArray()[0]));
            }
            return list;
        }

        public static int[,] Read2DIntArray(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            var y = lines.Length;
            var x = lines[0].Length;

            var array = new int[y, x];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    array[i, j] = int.Parse(lines[i][j].ToString());

                }
            }
            return array;
        }

    }
}

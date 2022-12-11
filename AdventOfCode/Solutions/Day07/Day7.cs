using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Day07
{
    public class Day7 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringList(@"Inputs\Day07.txt");

            var listWithAllFolders = new List<MyFolder>();

            var firstElement = new MyFolder();
            listWithAllFolders.Add(firstElement);
            var currentElement =  firstElement;

            foreach (var line in input) 
            {
                if (line.StartsWith("$"))
                {
                    //command -> switch folder or create folder/files
                    if (line.StartsWith("$ cd /"))
                    {
                        currentElement = firstElement;
                    }
                    else if (line.StartsWith("$ cd .."))
                    {
                        currentElement = currentElement.Parent;
                    }
                    else if (line .StartsWith("$ cd "))
                    {
                        currentElement = currentElement.MyFolders.FirstOrDefault(x => x.Name.Equals(line.Replace("$ cd ","")));
                    }
                }
                else
                {
                    if (line.StartsWith("dir "))
                    {
                        var folder = new MyFolder() { Name = line.Replace("dir ", ""), Parent = currentElement };
                        currentElement.MyFolders.Add(folder);
                        listWithAllFolders.Add(folder);
                    }
                    else
                    {
                        var newFile = new MyFile() { Size = int.Parse(line.Split(" ")[0]), Name = line.Split(" ")[1] };
                        currentElement.MyFiles.Add(newFile);
                    }
                }
            }
            var sum = 0;
            foreach (var folder in listWithAllFolders)
            {
                var size = folder.GetSize();
                if(size <= 100000)
                {
                    sum += size;
                }
            }
            Console.WriteLine(sum);
        }

        public void Solve2()
        {
            var input = InputReader.ReadStringList(@"Inputs\Day07.txt");

            var listWithAllFolders = new List<MyFolder>();

            var firstElement = new MyFolder();
            listWithAllFolders.Add(firstElement);
            var currentElement = firstElement;

            foreach (var line in input)
            {
                if (line.StartsWith("$"))
                {
                    //command -> switch folder or create folder/files
                    if (line.StartsWith("$ cd /"))
                    {
                        currentElement = firstElement;
                    }
                    else if (line.StartsWith("$ cd .."))
                    {
                        currentElement = currentElement.Parent;
                    }
                    else if (line.StartsWith("$ cd "))
                    {
                        currentElement = currentElement.MyFolders.FirstOrDefault(x => x.Name.Equals(line.Replace("$ cd ", "")));
                    }
                }
                else
                {
                    if (line.StartsWith("dir "))
                    {
                        var folder = new MyFolder() { Name = line.Replace("dir ", ""), Parent = currentElement };
                        currentElement.MyFolders.Add(folder);
                        listWithAllFolders.Add(folder);
                    }
                    else
                    {
                        var newFile = new MyFile() { Size = int.Parse(line.Split(" ")[0]), Name = line.Split(" ")[1] };
                        currentElement.MyFiles.Add(newFile);
                    }
                }
            }
            var candidates = new List<int>();

            var neededSpace = 30000000;
            var maxSpace = 70000000;
            var unusedSpace = maxSpace - firstElement.GetSize();


            foreach (var folder in listWithAllFolders)
            {
                var size = folder.GetSize();
                if (unusedSpace + size > neededSpace)
                {
                    candidates.Add(size);
                }
            }

            Console.WriteLine(candidates.Min());
        }
    }

    public class MyFolder
    {
        public MyFolder Parent { get; set; }
        public List<MyFolder> MyFolders { get; set; }
        public List<MyFile> MyFiles { get; set; }

        public MyFolder()
        {
            MyFolders = new List<MyFolder>();
            MyFiles = new List<MyFile>();
        }
        public string Name { get; set; }


        public int GetSize()
        {
            var sum = 0;
            foreach (var myFile in MyFiles)
            {
                sum += myFile.Size;
            }
            foreach (var myFolder in MyFolders)
            {
                sum += myFolder.GetSize();
            }
            return sum;
        }
    }

    public class MyFile
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }
}

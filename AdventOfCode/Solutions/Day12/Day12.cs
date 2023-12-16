using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Solutions.Day12
{
    internal class Day12 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.Read2DCharArray(@"Inputs\Day12.txt");

            foreach(var entry in input)
            {

            }

        }

        public void Solve2()
        {
            
        }



    }

    internal class Node
    {
        public List<Node> Neighbors { get; set; } = new List<Node>();
        bool IsEnd { get; set; } = false;

        public static void MakeNeighbors(Node node1, Node node2)
        {
            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node1);
        }

    }
    

}

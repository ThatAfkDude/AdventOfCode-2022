using AdventOfCode.Import;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Solutions.Day09
{
    internal class Day9 : ISolver
    {
        public void Solve()
        {
            var input = InputReader.ReadStringIntTuple(@"Inputs\Day09.txt");

            var headPos = new Point(0, 0);
            var tailPos = new Point(0, 0);
            var tailHistory = new List<Point>();
            var headHistory = new List<Point>();
            foreach (var item in input)
            {
                for(var i = 0; i < item.Item2; i++)
                {
                    headPos = MoveHead(item.Item1, headPos);
                    tailPos = MoveTail(headPos, tailPos);
                    tailHistory.Add(tailPos);
                    headHistory.Add(headPos);
                }
            }

            Console.WriteLine(tailHistory.Distinct().Count());
        }


        public void Solve2()
        {
            var input = InputReader.ReadStringIntTuple(@"Inputs\Day09.txt");

            var listPoints = new List<Point>();

            for(int i = 0; i < 10; i++)
            { 
                listPoints.Add(new Point(0, 0));
            }
            
            var headPos = new Point(0, 0);
            var tailHistory = new List<Point>();
            var headHistory = new List<Point>();
            foreach (var item in input)
            {
                for (var i = 0; i < item.Item2; i++)
                {
                    listPoints[0] = MoveHead(item.Item1, listPoints[0]);
                    for (int j = 1; j < 10; j++)
                    {
                        listPoints[j] = MoveTail(listPoints[j-1], listPoints[j]);
                    }

                    tailHistory.Add(listPoints[9]);
                    headHistory.Add(headPos);
                }
            }

            Console.WriteLine(tailHistory.Distinct().Count());
        }

        private Point MoveTail(Point headPos, Point tailPos)
        {
            var ax = headPos.X - tailPos.X;
            var ay = headPos.Y - tailPos.Y;

            var dx = Math.Abs(headPos.X - tailPos.X);
            var dy = Math.Abs(headPos.Y - tailPos.Y);

            if (dx == 2 && dy == 2)
            {
                var newX = ax > 0 ? -1 : 1;
                var newY = ay > 0 ? -1 : 1;
                tailPos = new Point(headPos.X + newX, headPos.Y + newY);
            }
            else if (dx == 2)
            {
                if(ax > 0)
                {
                    tailPos = new Point(headPos.X - 1, headPos.Y);
                }
                else
                {
                    tailPos = new Point(headPos.X + 1, headPos.Y);
                }   
            }else if (dy == 2)
            {
                if (ay > 0)
                {
                    tailPos = new Point(headPos.X , headPos.Y - 1);
                }
                else
                {
                    tailPos = new Point(headPos.X , headPos.Y + 1);
                }
            }
            return tailPos;
        }

        private Point MoveHead(string item1, Point head)
        {
            if (item1.Equals("R"))
            {
                head.X++;
            }
            if (item1.Equals("L"))
            {
                head.X--;
            }
            if (item1.Equals("U"))
            {
                head.Y++;
            }
            if (item1.Equals("D"))
            {
                head.Y--;
            }
            return head;
        }
    }
}

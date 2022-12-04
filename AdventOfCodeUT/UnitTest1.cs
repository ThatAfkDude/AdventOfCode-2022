using AdventOfCode.Solutions.Day02;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeUT
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(1 ,1, 3)]
        [DataRow(1, 2, 4)]
        [DataRow(1, 3, 8)]
        [DataRow(2, 1, 1)]
        [DataRow(2, 2, 5)]
        [DataRow(2, 3, 9)]
        [DataRow(3, 1, 2)]
        [DataRow(3, 2, 6)]
        [DataRow(3, 3, 7)]
        public void Day2_2_Score(int a, int b, int expected)
        {
            var res = Day2.GetScore(a,b);

            res.Should().Be(expected);
        }
    }
}

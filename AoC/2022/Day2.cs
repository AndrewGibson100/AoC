using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day2
    {
        public static int Part1(string input) => 
            GetResult(input, PointsForShapePt1, PointsForResultPt1);

        public static int Part2(string input) =>
            GetResult(input, PointsForShapePt2, PointsForResultPt2);

        private static int GetResult(string input, Func<string[], int> pointsForShape, Func<string[], int> pointsForResult) =>
            input.Split("\n")
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(" "))
            .Select(x => pointsForShape(x) + pointsForResult(x))
            .Sum();

        static int PointsForShapePt1(string[] strategy) =>
            strategy[1][0] - 87;

        static int PointsForShapePt2(string[] strategy) =>
            Wrap((strategy[0][0] - 65) + (strategy[1][0] - 89)) + 1;

        static int PointsForResultPt1(string[] strategy) =>
            3 + (3 * (Wrap((strategy[1][0] - 23) - strategy[0][0] + 1) - 1));

        static int PointsForResultPt2(string[] strategy) =>
            (strategy[1][0] - 88) * 3;

        static int Wrap(int val) =>
            ((val % 3) + 3) % 3;
    }
}

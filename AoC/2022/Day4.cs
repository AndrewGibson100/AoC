using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day4
    {
        public static int Part1(string input) =>
            GetResult(input, pair =>
                (pair[0] >= pair[2] && pair[1] <= pair[3]) ||
                pair[2] >= pair[0] && pair[3] <= pair[1]);

        public static int Part2(string input) =>
            GetResult(input, pair =>
                (pair[0] <= pair[2] && pair[1] >= pair[2]) ||
                pair[0] > pair[2] && pair[0] <= pair[3]);

        private static int GetResult(string input, Func<int[], bool> include) =>
            input.Split("\n")
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => line.Replace(",", "-")
                                    .Split("-")
                                    .Select(int.Parse)
                                    .ToArray())
                .Where(include)
                .Count();
    }
}

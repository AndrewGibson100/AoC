using AoC._2022.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    public class Day1
    {
        public static int Part1(string input) =>
            GetOrderedCals(input)
                .FirstOrDefault();

        public static int Part2(string input) =>
            GetOrderedCals(input)
                .Take(3)
                .Sum();

        static IOrderedEnumerable<int> GetOrderedCals(string input) =>
            input.Split("\n\n")
                .Select(elf =>
                    elf.Split("\n")
                        .Where(cal => !string.IsNullOrEmpty(cal))
                        .Select(int.Parse)
                        .Sum())
            .OrderByDescending(cal => cal);
    }
}

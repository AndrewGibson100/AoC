using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day3
    {
        public static int Part1(string input) =>
            input.Split("\n")
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => line.Take(line.Length / 2)
                    .Intersect(line.Skip(line.Length / 2)).First())
                .Select(Priority)
                .Sum();

        public static int Part2(string input) =>
            input.Split("\n")
                .Where(line => !string.IsNullOrEmpty(line))
                .Chunk(3)
                .Select(elfGroup =>
                    elfGroup.ElementAt(0)
                        .Intersect(elfGroup.ElementAt(1))
                        .Intersect(elfGroup.ElementAt(2))
                        .First())
                .Select(Priority)
                .Sum();

        private static int Priority(char itemType) =>
            char.IsLower(itemType) ? itemType - 96 : itemType - 38;
    }
}

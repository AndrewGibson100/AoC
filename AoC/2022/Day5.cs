using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day5
    {
        public static string Part1(string input)
        {
            var inputLines = input.Split("\n");

            var crateLines = GetStacks(inputLines);

            foreach (var move in GetMoves(inputLines))
                foreach (var crateToMove in Enumerable.Range(0, move[0])
                                                    .Select(x => crateLines[move[1] - 1].Pop()))
                        crateLines[move[2] - 1].Push(crateToMove);

            return new string(
                crateLines.Select(x => x.Pop()).ToArray());
        }

        public static string Part2(string input)
        {
            var inputLines = input.Split("\n");

            var crateLines = GetStacks(inputLines);

            foreach (var move in GetMoves(inputLines))
                foreach (var stackToMove in Enumerable.Range(0, move[0])
                                                    .Select(x => crateLines[move[1] - 1].Pop())
                                                    .Reverse())
                        crateLines[move[2] - 1].Push(stackToMove);

            return new string(
                crateLines.Select(x => x.Pop()).ToArray());
        }

        private static Stack<char>[] GetStacks(string[] inputLines) =>
            inputLines
                .TakeWhile(line => !line.Trim().StartsWith("1"))
                .SelectMany(line => Enumerable.Range(0, 9)
                                        .Select<int, char?>(i => line[i * 4] == '[' ? line[i * 4 + 1] : null)
                                        .ToArray())
                .Select((crate, i) => new { Crate = crate, Stack = i % 9 })
                .GroupBy(x => x.Stack)
                .Select(stackGroup => new Stack<char>(
                    stackGroup.Where(x => x.Crate.HasValue)
                            .Select(x => x.Crate.Value)
                            .Reverse()))
                .ToArray();

        private static IEnumerable<int[]> GetMoves(string[] inputLines) =>
            inputLines
                .SkipWhile(line => !line.StartsWith("move"))
                .TakeWhile(line => !string.IsNullOrEmpty(line))
                .Select(line => line.Split(" ")
                                    .Where(s => int.TryParse(s, out var i))
                                    .Select(int.Parse)
                                    .ToArray());
    }
}

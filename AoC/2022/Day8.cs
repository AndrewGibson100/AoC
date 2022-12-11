using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day8
    {
        public static int Part1(string input)
        {
            var forest = GetForest(input);
            var visCount = 0;
            for (int ri = 0; ri < forest.Length; ri++)
                for (int ti = 0; ti < forest[ri].Length; ti++)
                {
                    bool blockedU = false, blockedR = false, blockedD = false, blockedL = false;
                    var i = 1;
                    var tree = forest[ri][ti];
                    while (true)
                    {
                        if (ri - i >= 0 && forest[ri - i][ti] >= tree)
                            blockedU = true;
                        if (ri + i < forest.Length && forest[ri + i][ti] >= tree)
                            blockedD = true;
                        if (ti - i >= 0 && forest[ri][ti - i] >= tree)
                            blockedL = true;
                        if (ti + i < forest[ri].Length && forest[ri][ti + i] >= tree)
                            blockedR = true;
                        i++;
                        if ((blockedU && blockedD && blockedL && blockedR) ||
                            (ri - i < 0 && ri + i >= forest.Length && ti - i < 0 && ti + i >= forest[ri].Length))
                            break;
                    }
                    if (!blockedU || !blockedD || !blockedL || !blockedR)
                        visCount++;
                }
            return visCount;
        }

        public static int Part2(string input)
        {
            var forest = GetForest(input);
            var highScore = 0;
            for (int ri = 0; ri < forest.Length; ri++)
                for (int ti = 0; ti < forest[ri].Length; ti++)
                {
                    bool blockedU = false, blockedD = false, blockedL = false, blockedR = false;
                    int up = 0, down = 0, left = 0, right = 0;
                    var i = 1;
                    var tree = forest[ri][ti];
                    while (true)
                    {
                        if (ri - i >= 0)
                        {
                            if (!blockedU) up++;
                            if (forest[ri - i][ti] >= tree) blockedU = true;
                        }
                        if (ri + i < forest.Length)
                        {
                            if (!blockedD) down++;
                            if (forest[ri + i][ti] >= tree) blockedD = true;
                        }
                        if (ti - i >= 0)
                        {
                            if (!blockedL) left++;
                            if (forest[ri][ti - i] >= tree) blockedL = true;
                        }
                        if (ti + i < forest[ri].Length)
                        {
                            if (!blockedR) right++;
                            if (forest[ri][ti + i] >= tree) blockedR = true;
                        }
                        i++;
                        if ((blockedU && blockedD && blockedL && blockedR) ||
                            (ri - i < 0 && ri + i >= forest.Length && ti - i < 0 && ti + i >= forest[ri].Length))
                        {
                            var score = up * down * left * right;
                            if (score > highScore) highScore = score;
                            break;
                        }
                    }
                }
            return highScore;
        }

        private static int[][] GetForest(string input) =>
            input.Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .Select(row => row.Select(c => int.Parse(c.ToString())).ToArray())
                .ToArray();
    }
}

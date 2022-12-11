using AoC._2022.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day10
    {
        public static int Part1(string input)
        {
            var split = input.Split("\n").Where(x => !string.IsNullOrEmpty(x));
            var cycle = 0;
            var x = 1;
            var result = 0;
            foreach (var line in split)
            {
                cycle++;
                if (cycle == 20 || (cycle - 20) % 40 == 0)
                    result += x * cycle;

                if (line != "noop")
                {
                    cycle++;
                    if (cycle == 20 || (cycle - 20) % 40 == 0)
                        result += x * cycle;

                    x += int.Parse(line.Split(" ")[1]);
                }
            }
            return result;
        }

        public static string Part2(string input)
        {
            var split = input.Split("\n").Where(x => !string.IsNullOrEmpty(x));
            var cycle = 1;
            var x = 1;
            var screen = new List<string>();
            foreach (var line in split)
            {
                if (line == "noop")
                {
                    if (Math.Abs(x - (cycle % 40) + 1) < 2)
                        screen.Add("#");
                    else
                        screen.Add(".");
                    cycle++;
                }
                else
                {
                    if (Math.Abs(x - (cycle % 40) + 1) < 2)
                        screen.Add("#");
                    else
                        screen.Add(".");
                    cycle++;
                    if (Math.Abs(x - (cycle % 40) + 1) < 2)
                        screen.Add("#");
                    else
                        screen.Add(".");
                    cycle++;
                    x += int.Parse(line.Split(" ")[1]);
                }

            }
            return string.Join(Environment.NewLine, screen.Chunk(40).Select(x => string.Join("", x)));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day9
    {
        public static int Part1(string input) =>
            GetAnswer(input, 2);

        public static int Part2(string input) =>
            GetAnswer(input, 10);

        static int GetAnswer(string input, int knotCount)
        {
            var s = new HashSet<string>() { "0:0" };
            var coords = Enumerable.Range(0, knotCount).Select(x => new int[] { 0, 0 }).ToList();
            var h = coords[0];
            foreach (var line in input.Split("\n").Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                var direction = line.Split(" ")[0];
                var count = int.Parse(line.Split(" ")[1]);

                for (int i = 0; i < count; i++)
                {
                    if (direction == "D")
                        h[1]--;
                    else if (direction == "U")
                        h[1]++;
                    else if (direction == "R")
                        h[0]++;
                    else if (direction == "L")
                        h[0]--;

                    var parent = h;
                    foreach (var knot in coords.Skip(1))
                    {
                        var yDif = parent[1] - knot[1];
                        var xDif = parent[0] - knot[0];
                        if (parent[0] == knot[0])
                        {
                            if (Math.Abs(yDif) > 1)
                                knot[1] += yDif < 0 ? -1 : 1;
                        }
                        else if (parent[1] == knot[1])
                        {
                            if (Math.Abs(xDif) > 1)
                                knot[0] += xDif < 0 ? -1 : 1;
                        }
                        else
                        {
                            if (Math.Abs(yDif) > 1 || Math.Abs(xDif) > 1)
                            {
                                knot[1] += yDif < 0 ? -1 : 1;
                                knot[0] += xDif < 0 ? -1 : 1;
                            }
                        }

                        parent = knot;
                    }

                    s.Add($"{coords[^1][0]}:{coords[^1][1]}");
                }

            }
            return s.Count;
        }
    }
}

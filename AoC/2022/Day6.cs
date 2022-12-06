using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day6
    {
        public static int Part1(string input) =>
            GetResult(input, 4);

        public static int Part2(string input) =>
            GetResult(input, 14);

        static int GetResult(string input, int uniqueCount) =>
            input.Select((c, i) => new 
            { 
                Pos = i + uniqueCount, 
                SubStr = input.Skip(i).Take(uniqueCount) 
            })
                .First(x => x.SubStr.Distinct().Count() == x.SubStr.Count())
                .Pos;
    }
}

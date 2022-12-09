using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC._2022
{
    internal class Day7
    {
        public static int Part1(string input) =>
            GetDirs(input)
                .Where(dir => dir.Size <= 100000)
                .Sum(dir => dir.Size);

        public static int Part2(string input) =>
            GetDirs(input)
                .Aggregate(new { RequiredSpace = 0, SmallestDir = 0 }, (accum, dir) => new
                {
                    RequiredSpace = accum.RequiredSpace == 0 ?
                        30000000 - (70000000 - dir.Size) : accum.RequiredSpace,
                    SmallestDir = dir.Size >= accum.RequiredSpace &&
                        (dir.Size < accum.SmallestDir || accum.SmallestDir == 0) ?
                        dir.Size : accum.SmallestDir
                }).SmallestDir;

        static (string Parent, string Dir, int Size)[] GetDirs(string input) =>
            input.Split("\n")
                 .Aggregate(new
                 {
                     DirStack = new (string Parent, string Dir)[0],
                     AllDirs = new (string Parent, string Dir, int Size)[] { (null, "/", 0) }
                 },
                 (accum, line) => line.Split(" ") switch
                 {
                     ["$", "ls"] => accum, // do nothing
                     ["$", "cd", ".."] => new { DirStack = accum.DirStack[..^1], accum.AllDirs }, // pop from the stack
                     ["$", "cd", var dir] => new // add to the stack
                     {
                         DirStack = accum.DirStack.Concat(new[] { (Parent: accum.DirStack.LastOrDefault().Dir, Dir: dir) }).ToArray(),
                         accum.AllDirs
                     },
                     ["dir", var dir] => new // add to directory list if doesn't already exist
                     {
                         accum.DirStack,
                         AllDirs = accum.AllDirs.Any(x => x.Dir == dir && x.Parent == accum.DirStack.Last().Dir) ?
                             accum.AllDirs :
                             accum.AllDirs.Concat(new[] { (accum.DirStack.Last().Dir, dir, 0) }).ToArray()
                     },
                     [var fileSize, _] => new // Increment file size for every dir in current stack
                     {
                         accum.DirStack,
                         AllDirs = accum.AllDirs.Select(
                             dir =>
                                 (dir.Parent,
                                  dir.Dir,
                                  Size: dir.Size + (accum.DirStack.Any(
                                     stack => stack.Dir == dir.Dir && stack.Parent == dir.Parent) ?
                                     int.Parse(fileSize) : 0)))
                             .ToArray()
                     },
                     _ => accum
                 })
                 .AllDirs;
    }
}

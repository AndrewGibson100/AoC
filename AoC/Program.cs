// See https://aka.ms/new-console-template for more information
using AoC._2022;
using AoC._2022.Common;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

var input = await Input.GetInput(12);

var grid = input.Split("\n").Select(x => x.ToArray()).ToArray();

var sx = 0;
var sy = 0;
for (int ri = 0; ri < grid.Length; ri++)
	for (int i = 0; i < grid[ri].Length; i++)
		if (grid[ri][i] == 'S')
		{
			sy = ri;
			sx = i;
            grid[ri][i] = 'a';
		}

var paths = new List<(string Path, List<AvailableMove> OtherAvailableMoves)>();
var currentPath = new Path { Cx = sx, Cy = sy, Moves = "" };
var pathStack = new Stack<Path>();
var viablePaths = new HashSet<string>();

while (true)
{
	var c = grid[currentPath.Cy][currentPath.Cx];
	var availableMoves = new List<AvailableMove>();

    var a = currentPath.Cx + 1 < grid[currentPath.Cy].Length;
    var b = grid[currentPath.Cy][currentPath.Cx + 1] <= grid[currentPath.Cy][currentPath.Cx] + 1;
    var d = (grid[currentPath.Cy][currentPath.Cx + 1] == 'E' && c >= 'y');


    if (currentPath.Cx + 1 < grid[currentPath.Cy].Length && (grid[currentPath.Cy][currentPath.Cx + 1] <= grid[currentPath.Cy][currentPath.Cx] + 1 || (grid[currentPath.Cy][currentPath.Cx + 1] == 'E' && c >= 'y')))
	{
		if (grid[currentPath.Cy][currentPath.Cx + 1] == 'E' && c >= 'y')
		{
            // Found end
            viablePaths.Add(currentPath.Moves);
            var alternativeMoves = currentPath.AlternativeMoves.Where(x => x.Any()).LastOrDefault();
            if (alternativeMoves != null)
            {
                var altMove = alternativeMoves.First();
                var newMoves = currentPath.Moves.Substring(0, altMove.PathIndex);
                alternativeMoves.Remove(altMove);
                if (currentPath.AlternativeMoves.Any(x => x.Any()))
                    pathStack.Push(currentPath);
                currentPath = new Path { Cx = altMove.ToX, Cy = altMove.ToY, Moves = newMoves, Visited = new HashSet<string>(currentPath.Visited) };
            }
            else if (pathStack.Any())
                currentPath = pathStack.Pop();
            else
                break;

            continue;
		}
        if (!currentPath.Visited.Contains($"{currentPath.Cx + 1}:{currentPath.Cy}"))
            availableMoves.Add(new AvailableMove { FromX = currentPath.Cx, FromY = currentPath.Cy, ToX = currentPath.Cx + 1, ToY = currentPath.Cy, Move = "R", PathIndex = currentPath.Moves.Length });
    }
    if (currentPath.Cx - 1 >= 0 && (grid[currentPath.Cy][currentPath.Cx - 1] <= grid[currentPath.Cy][currentPath.Cx] + 1 || (grid[currentPath.Cy][currentPath.Cx - 1] == 'E' && c >= 'y')))
    {
        if (grid[currentPath.Cy][currentPath.Cx - 1] == 'E' && c >= 'y')
        {
            // Found end
            viablePaths.Add(currentPath.Moves);
            var alternativeMoves = currentPath.AlternativeMoves.Where(x => x.Any()).LastOrDefault();
            if (alternativeMoves != null)
            {
                var altMove = alternativeMoves.First();
                var newMoves = currentPath.Moves.Substring(0, altMove.PathIndex);
                alternativeMoves.Remove(altMove);
                if (currentPath.AlternativeMoves.Any(x => x.Any()))
                    pathStack.Push(currentPath);
                currentPath = new Path { Cx = altMove.ToX, Cy = altMove.ToY, Moves = newMoves, Visited = new HashSet<string>(currentPath.Visited) };
            }
            else if (pathStack.Any())
                currentPath = pathStack.Pop();
            else
                break;

            continue;
        }
        if (!currentPath.Visited.Contains($"{currentPath.Cx - 1}:{currentPath.Cy}"))
            availableMoves.Add(new AvailableMove { FromX = currentPath.Cx, FromY = currentPath.Cy, ToX = currentPath.Cx - 1, ToY = currentPath.Cy, Move = "L", PathIndex = currentPath.Moves.Length });
    }
    if (currentPath.Cy + 1 < grid.Length && (grid[currentPath.Cy + 1][currentPath.Cx] <= grid[currentPath.Cy][currentPath.Cx] + 1 || (grid[currentPath.Cy + 1][currentPath.Cx] == 'E' && c >= 'y')))
    {
        if (grid[currentPath.Cy + 1][currentPath.Cx] == 'E' && c >= 'y')
        {
            // Found end
            viablePaths.Add(currentPath.Moves);
            var alternativeMoves = currentPath.AlternativeMoves.Where(x => x.Any()).LastOrDefault();
            if (alternativeMoves != null)
            {
                var altMove = alternativeMoves.First();
                var newMoves = currentPath.Moves.Substring(0, altMove.PathIndex);
                alternativeMoves.Remove(altMove);
                if (currentPath.AlternativeMoves.Any(x => x.Any()))
                    pathStack.Push(currentPath);
                currentPath = new Path { Cx = altMove.ToX, Cy = altMove.ToY, Moves = newMoves, Visited = new HashSet<string>(currentPath.Visited) };
            }
            else if (pathStack.Any())
                currentPath = pathStack.Pop();
            else
                break;

            continue;
        }
        if (!currentPath.Visited.Contains($"{currentPath.Cx}:{currentPath.Cy + 1}"))
            availableMoves.Add(new AvailableMove { FromX = currentPath.Cx, FromY = currentPath.Cy, ToX = currentPath.Cx, ToY = currentPath.Cy + 1, Move = "D", PathIndex = currentPath.Moves.Length });
    }
    if (currentPath.Cy - 1 >= 0 && (grid[currentPath.Cy - 1][currentPath.Cx] <= grid[currentPath.Cy][currentPath.Cx] + 1 || (grid[currentPath.Cy - 1][currentPath.Cx] == 'E' && c >= 'y')))
    {
        if (grid[currentPath.Cy - 1][currentPath.Cx] == 'E' && c >= 'y')
        {
            // Found end
            viablePaths.Add(currentPath.Moves);
            var alternativeMoves = currentPath.AlternativeMoves.Where(x => x.Any()).LastOrDefault();
            if (alternativeMoves != null)
            {
                var altMove = alternativeMoves.First();
                var newMoves = currentPath.Moves.Substring(0, altMove.PathIndex);
                alternativeMoves.Remove(altMove);
                if (currentPath.AlternativeMoves.Any(x => x.Any()))
                    pathStack.Push(currentPath);
                currentPath = new Path { Cx = altMove.ToX, Cy = altMove.ToY, Moves = newMoves, Visited = new HashSet<string>(currentPath.Visited) };
            }
            else if (pathStack.Any())
                currentPath = pathStack.Pop();
            else
                break;

            continue;
        }
        if (!currentPath.Visited.Contains($"{currentPath.Cx}:{currentPath.Cy - 1}"))
            availableMoves.Add(new AvailableMove { FromX = currentPath.Cx, FromY = currentPath.Cy, ToX = currentPath.Cx, ToY = currentPath.Cy - 1, Move = "U", PathIndex = currentPath.Moves.Length });
    }

    if (!availableMoves.Any())
    {
        // dead end
        var alternativeMoves = currentPath.AlternativeMoves.Where(x => x.Any()).LastOrDefault();
        if (alternativeMoves != null)
        {
            var altMove = alternativeMoves.First();
            var newMoves = currentPath.Moves.Substring(0, altMove.PathIndex);
            alternativeMoves.Remove(altMove);
            if (currentPath.AlternativeMoves.Any(x => x.Any()))
                pathStack.Push(currentPath);
            currentPath = new Path { Cx = altMove.ToX, Cy = altMove.ToY, Moves = newMoves, Visited = new HashSet<string>(currentPath.Visited) };
        }
        else if (pathStack.Any())
            currentPath = pathStack.Pop();
        else
            break;

        continue;
    }

    if (currentPath.Moves.LastOrDefault() == 'R' && availableMoves[0].Move == "L")
    {
        var test = 1;
    }

    currentPath.Moves += availableMoves[0].Move;
    currentPath.Cx = availableMoves[0].ToX;
    currentPath.Cy = availableMoves[0].ToY;
    currentPath.Visited.Add($"{currentPath.Cx}:{currentPath.Cy}");
    if (availableMoves.Count > 1)
        currentPath.AlternativeMoves.Add(availableMoves.Skip(1).ToList());
}

var result = viablePaths.OrderByDescending(x => x.Length).First().Length + 1;

Console.WriteLine(result);
Console.Read();

public class Path
{
    public string Moves { get; set; }
    public List<List<AvailableMove>> AlternativeMoves { get; set; } = new List<List<AvailableMove>>();
    public HashSet<string> Visited { get; set; } = new HashSet<string>();
    public int Cx { get; set; }
    public int Cy { get; set; }
}


public class AvailableMove
{
	public int FromX { get; set; }
	public int FromY { get; set; }
	public int ToX { get; set; }
	public int ToY { get; set; }
    public string Move { get; set; }
    public int PathIndex { get; set; }
}



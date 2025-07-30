using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    // Problem 1 (Keep exactly the same)
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2 (Keep exactly the same)
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char currentChar = letters[i];
            string remainingLetters = letters.Remove(i, 1);
            PermutationsChoose(results, remainingLetters, size, word + currentChar);
        }
    }

    // Problem 3 (Keep exactly the same)
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal> remember = null)
    {
        remember ??= new Dictionary<int, decimal>();
        if (remember.ContainsKey(s)) return remember[s];

        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        decimal ways = CountWaysToClimb(s - 1, remember) + 
                     CountWaysToClimb(s - 2, remember) + 
                     CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    // Problem 4 (Keep exactly the same)
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildcardIndex = pattern.IndexOf('*');
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        string prefix = pattern[..wildcardIndex];
        string suffix = pattern[(wildcardIndex + 1)..];

        WildcardBinary(prefix + "0" + suffix, results);
        WildcardBinary(prefix + "1" + suffix, results);
    }

    // Problem 5 (Only change IsEnd to CheckEnd)
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int x, int y)> currPath = null)
    {
        currPath ??= new List<(int x, int y)>();
        currPath.Add((x, y));

        if (maze.CheckEnd(x, y))  // Changed from IsEnd to CheckEnd
        {
            results.Add(PathToString(currPath));
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        TryMove(results, maze, x + 1, y, new List<(int x, int y)>(currPath));
        TryMove(results, maze, x, y + 1, new List<(int x, int y)>(currPath));
        TryMove(results, maze, x - 1, y, new List<(int x, int y)>(currPath));
        TryMove(results, maze, x, y - 1, new List<(int x, int y)>(currPath));

        currPath.RemoveAt(currPath.Count - 1);
    }

    private static void TryMove(List<string> results, Maze maze, int x, int y, List<(int x, int y)> path)
    {
        if (maze.IsValidMove(x, y, path))
            SolveMaze(results, maze, x, y, path);
    }

    private static string PathToString(List<(int x, int y)> path)
    {
        return string.Join("->", path.Select(p => $"({p.x},{p.y})"));
    }
}

public class Maze
{
    private readonly int[,] grid;
    private readonly int size;
    private readonly (int x, int y) endPosition;

    public Maze(int[,] grid, (int x, int y) endPosition)
    {
        this.grid = grid ?? throw new ArgumentNullException(nameof(grid));
        this.size = grid.GetLength(0);
        this.endPosition = endPosition;
    }

    public bool CheckEnd(int x, int y) => x == endPosition.x && y == endPosition.y;  // Renamed from IsEnd

    public bool IsValidMove(int x, int y, List<(int x, int y)> path)
    {
        if (x < 0 || x >= size || y < 0 || y >= size) return false;
        if (grid[x, y] == 0) return false;
        return !path.Any(p => p.x == x && p.y == y);
    }
}
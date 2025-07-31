using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    // Problem 1: Sum of squares
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(
                results,
                letters.Remove(i, 1),
                size,
                word + letters[i]
            );
        }
    }

    // Problem 3: Climbing stairs
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        var memo = remember ?? new Dictionary<int, decimal>();
        if (memo.ContainsKey(s)) return memo[s];

        // Base cases
        if (s < 0) return 0;
        if (s == 0) return 1;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        decimal ways = CountWaysToClimb(s - 1, memo) 
                     + CountWaysToClimb(s - 2, memo) 
                     + CountWaysToClimb(s - 3, memo);
        memo[s] = ways;
        return ways;
    }

    // Problem 4: Wildcard binary
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int wildIndex = pattern.IndexOf('*');
        if (wildIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern[..wildIndex] + "0" + pattern[(wildIndex + 1)..], results);
        WildcardBinary(pattern[..wildIndex] + "1" + pattern[(wildIndex + 1)..], results);
    }

    // Problem 5: Maze solver (fixed output format)
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int x, int y)>? currPath = null)
    {
        var path = currPath ?? new List<(int x, int y)>();
        path.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(PathToString(path));
            path.RemoveAt(path.Count - 1);
            return;
        }

        var pathForValidation = path.Select(p => new ValueTuple<int, int>(p.x, p.y)).ToList();
        
        // Try all directions
        if (maze.IsValidMove(pathForValidation, x + 1, y))
            SolveMaze(results, maze, x + 1, y, new List<(int x, int y)>(path));
        if (maze.IsValidMove(pathForValidation, x, y + 1))
            SolveMaze(results, maze, x, y + 1, new List<(int x, int y)>(path));
        if (maze.IsValidMove(pathForValidation, x - 1, y))
            SolveMaze(results, maze, x - 1, y, new List<(int x, int y)>(path));
        if (maze.IsValidMove(pathForValidation, x, y - 1))
            SolveMaze(results, maze, x, y - 1, new List<(int x, int y)>(path));

        path.RemoveAt(path.Count - 1);
    }

    // Fixed to match test's expected format
    private static string PathToString(List<(int x, int y)> path)
    {
        return $"<List>{{{string.Join(", ", path.Select(p => $"({p.x}, {p.y})"))}}}";
    }
}
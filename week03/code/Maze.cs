using System;
using System.Collections.Generic;

public class Maze
{
    /// <summary>
    /// Checks if left movement is allowed from current position
    /// </summary>
    public static bool MoveLeft((int x, int y) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (!maze.ContainsKey(pos)) return false;
        return maze[pos].left && pos.x > 1;
    }

    /// <summary>
    /// Checks if right movement is allowed from current position
    /// </summary>
    public static bool MoveRight((int x, int y) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (!maze.ContainsKey(pos)) return false;
        return maze[pos].right && pos.x < 6;
    }

    /// <summary>
    /// Checks if upward movement is allowed from current position
    /// </summary>
    public static bool MoveUp((int x, int y) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (!maze.ContainsKey(pos)) return false;
        return maze[pos].up && pos.y > 1;
    }

    /// <summary>
    /// Checks if downward movement is allowed from current position
    /// </summary>
    public static bool MoveDown((int x, int y) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (!maze.ContainsKey(pos)) return false;
        return maze[pos].down && pos.y < 6;
    }

    /// <summary>
    /// Checks if movement in specified direction is valid
    /// </summary>
    public static bool CanMove((int x, int y) pos, string direction, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (string.IsNullOrWhiteSpace(direction)) return false;

        direction = direction.ToLower();
        switch (direction)
        {
            case "left": return MoveLeft(pos, maze);
            case "right": return MoveRight(pos, maze);
            case "up": return MoveUp(pos, maze);
            case "down": return MoveDown(pos, maze);
            default: return false;
        }
    }

    /// <summary>
    /// Represents a node in the maze for pathfinding
    /// </summary>
    private class MazeNode
    {
        public (int x, int y) Position { get; set; }
        public List<string> Path { get; set; } = new List<string>();
    }

    /// <summary>
    /// Finds path from start to end using BFS algorithm
    /// </summary>
    public static List<string> SolveMaze(
        (int x, int y) start,
        (int x, int y) end,
        Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (!maze.ContainsKey(start) || !maze.ContainsKey(end))
            return null;

        var visited = new HashSet<(int, int)>();
        var queue = new Queue<MazeNode>();
        queue.Enqueue(new MazeNode { Position = start });

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Position == end)
                return current.Path;

            if (visited.Contains(current.Position))
                continue;

            visited.Add(current.Position);

            // Explore all possible directions
            if (MoveLeft(current.Position, maze))
            {
                queue.Enqueue(new MazeNode
                {
                    Position = (current.Position.x - 1, current.Position.y),
                    Path = new List<string>(current.Path) { "left" }
                });
            }

            if (MoveRight(current.Position, maze))
            {
                queue.Enqueue(new MazeNode
                {
                    Position = (current.Position.x + 1, current.Position.y),
                    Path = new List<string>(current.Path) { "right" }
                });
            }

            if (MoveUp(current.Position, maze))
            {
                queue.Enqueue(new MazeNode
                {
                    Position = (current.Position.x, current.Position.y - 1),
                    Path = new List<string>(current.Path) { "up" }
                });
            }

            if (MoveDown(current.Position, maze))
            {
                queue.Enqueue(new MazeNode
                {
                    Position = (current.Position.x, current.Position.y + 1),
                    Path = new List<string>(current.Path) { "down" }
                });
            }
        }

        return null; // No path found
    }
}
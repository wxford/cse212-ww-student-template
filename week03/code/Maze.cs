using System;
using System.Collections.Generic;

public class Maze
{
    public static (int, int) MoveLeft((int, int) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.ContainsKey(pos) && maze[pos].left)
        {
            var newPos = (pos.Item1 - 1, pos.Item2);
            if (maze.ContainsKey(newPos))
                return newPos;
        }
        return pos;
    }

    public static (int, int) MoveRight((int, int) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.ContainsKey(pos) && maze[pos].right)
        {
            var newPos = (pos.Item1 + 1, pos.Item2);
            if (maze.ContainsKey(newPos))
                return newPos;
        }
        return pos;
    }

    public static (int, int) MoveUp((int, int) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.ContainsKey(pos) && maze[pos].up)
        {
            var newPos = (pos.Item1, pos.Item2 - 1);
            if (maze.ContainsKey(newPos))
                return newPos;
        }
        return pos;
    }

    public static (int, int) MoveDown((int, int) pos, Dictionary<(int, int), (bool left, bool right, bool up, bool down)> maze)
    {
        if (maze.ContainsKey(pos) && maze[pos].down)
        {
            var newPos = (pos.Item1, pos.Item2 + 1);
            if (maze.ContainsKey(newPos))
                return newPos;
        }
        return pos;
    }
}

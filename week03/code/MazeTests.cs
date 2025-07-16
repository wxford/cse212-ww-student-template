using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class MazeTests
{
    private Dictionary<(int, int), (bool left, bool right, bool up, bool down)> sampleMaze;

    [TestInitialize]
    public void Setup()
    {
        // Initialize a simple maze:
        sampleMaze = new Dictionary<(int, int), (bool, bool, bool, bool)>
        {
            [(1, 1)] = (false, true, false, true),  // Can move right and down
            [(2, 1)] = (true, true, false, false),  // Can move left and right
            [(1, 2)] = (false, false, true, false)   // Can move up
        };
    }

    [TestMethod]
    public void MoveLeft_ValidMove_ReturnsTrue()
    {
        var pos = (2, 1);
        Assert.IsTrue(Maze.MoveLeft(pos, sampleMaze));
    }

    [TestMethod]
    public void MoveLeft_InvalidMove_ReturnsFalse()
    {
        var pos = (1, 1);
        Assert.IsFalse(Maze.MoveLeft(pos, sampleMaze));
    }

    [TestMethod]
    public void MoveRight_ValidMove_ReturnsTrue()
    {
        var pos = (1, 1);
        Assert.IsTrue(Maze.MoveRight(pos, sampleMaze));
    }

    [TestMethod]
    public void MoveRight_BoundaryCheck_ReturnsFalse()
    {
        var pos = (6, 1); // Assume x=6 is the right boundary
        Assert.IsFalse(Maze.MoveRight(pos, sampleMaze));
    }

    // Add similar tests for MoveUp and MoveDown
}
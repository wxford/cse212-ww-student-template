using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    /*
    Test: People should return in turn and return to the queue if they have remaining turns.
    Result: Passes after fixing the GetNextPerson() logic to re-enqueue when needed.
    */
    [TestMethod]
    public void TestNormalTurns()
    {
        TakingTurnsQueue queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 2);
        queue.AddPerson("Bob", 1);

        Assert.AreEqual("Alice", queue.GetNextPerson());
        Assert.AreEqual("Bob", queue.GetNextPerson());
        Assert.AreEqual("Alice", queue.GetNextPerson());
    }

    /*
    Test: Person with infinite turns (0 or less) should always be re-added.
    Result: Passes after fixing logic to check <= 0 for infinite.
    */
    [TestMethod]
    public void TestInfiniteTurns()
    {
        TakingTurnsQueue queue = new TakingTurnsQueue();
        queue.AddPerson("InfiniteGuy", 0);

        Assert.AreEqual("InfiniteGuy", queue.GetNextPerson());
        Assert.AreEqual("InfiniteGuy", queue.GetNextPerson());
    }

    /*
    Test: Should throw error if queue is empty.
    Result: Passes.
    */
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestEmptyQueueThrows()
    {
        TakingTurnsQueue queue = new TakingTurnsQueue();
        queue.GetNextPerson();
    }
}

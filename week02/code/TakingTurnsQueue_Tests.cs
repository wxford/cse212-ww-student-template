using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    [TestMethod]
    public void TestInfiniteTurns()
    {
        // Expectation: Infinite-turn person always comes back into the queue.
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 0);

        Assert.AreEqual("Alice", queue.GetNextPerson());
        Assert.AreEqual("Alice", queue.GetNextPerson());
        Assert.AreEqual("Alice", queue.GetNextPerson());
        // ✅ Passes: Alice has infinite turns.
    }

    [TestMethod]
    public void TestLimitedTurns()
    {
        // Expectation: Person with 2 turns should appear twice, then be gone.
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 2);

        Assert.AreEqual("Bob", queue.GetNextPerson());
        Assert.AreEqual("Bob", queue.GetNextPerson());

        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
        // ✅ Passes: Bob had 2 turns and was removed after.
    }

    [TestMethod]
    public void TestEmptyQueueThrows()
    {
        // Expectation: Empty queue throws exception on dequeue.
        var queue = new TakingTurnsQueue();
        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
        // ✅ Passes: Properly throws on empty.
    }

    [TestMethod]
    public void TestMultiplePeople()
    {
        // Expectation: Alice (∞), Bob (2), Charlie (1)
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 0);
        queue.AddPerson("Bob", 2);
        queue.AddPerson("Charlie", 1);

        Assert.AreEqual("Alice", queue.GetNextPerson());   // A ∞
        Assert.AreEqual("Bob", queue.GetNextPerson());     // B 1 left
        Assert.AreEqual("Charlie", queue.GetNextPerson()); // C removed
        Assert.AreEqual("Alice", queue.GetNextPerson());   // A ∞
        Assert.AreEqual("Bob", queue.GetNextPerson());     // B removed
        Assert.AreEqual("Alice", queue.GetNextPerson());   // A ∞
        // ✅ Passes: Order and logic are correct.
    }
}

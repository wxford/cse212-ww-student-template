using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueue_Tests
{
    /*
    Test: Highest priority value should be dequeued.
    Result: Passes.
    */
    [TestMethod]
    public void TestDequeueHighestPriority()
    {
        PriorityQueue queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("High", 5);
        Assert.AreEqual("High", queue.Dequeue());
    }

    /*
    Test: FIFO preserved for same priority.
    Result: Passes after fixing logic to find the first item with max priority.
    */
    [TestMethod]
    public void TestFIFOWithSamePriority()
    {
        PriorityQueue queue = new PriorityQueue();
        queue.Enqueue("First", 3);
        queue.Enqueue("Second", 3);
        Assert.AreEqual("First", queue.Dequeue());
    }

    /*
    Test: Should throw error if queue is empty.
    Result: Passes.
    */
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestDequeueEmptyQueue()
    {
        PriorityQueue queue = new PriorityQueue();
        queue.Dequeue();
    }
}

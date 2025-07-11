using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    public void TestSingleEnqueueDequeue()
    {
        // Expectation: Dequeue should return the single item added.
        var pq = new PriorityQueue();
        pq.Enqueue("Task1", 5);
        Assert.AreEqual("Task1", pq.Dequeue());
        // ✅ Passes: Single item dequeued successfully.
    }

    [TestMethod]
    public void TestHighestPriorityDequeue()
    {
        // Expectation: Highest priority value should be dequeued.
        var pq = new PriorityQueue();
        pq.Enqueue("Task1", 2);
        pq.Enqueue("Task2", 5);
        pq.Enqueue("Task3", 1);

        Assert.AreEqual("Task2", pq.Dequeue());
        // ✅ Passes: Task2 had the highest priority (5).
    }

    [TestMethod]
    public void TestFIFOOnSamePriority()
    {
        // Expectation: If priorities are equal, first entered dequeued first.
        var pq = new PriorityQueue();
        pq.Enqueue("First", 3);
        pq.Enqueue("Second", 3);

        Assert.AreEqual("First", pq.Dequeue());
        // ✅ Passes: FIFO is preserved when priority is tied.
    }

    [TestMethod]
    public void TestEmptyQueueThrows()
    {
        // Expectation: Dequeue from empty queue should throw exception.
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        // ✅ Passes: Exception thrown as expected.
    }
}

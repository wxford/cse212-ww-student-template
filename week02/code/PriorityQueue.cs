using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueueItem
{
    public string Value { get; }
    public int Priority { get; }

    public PriorityQueueItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }
}

public class PriorityQueue
{
    private List<PriorityQueueItem> items = new List<PriorityQueueItem>();

    public void Enqueue(string value, int priority)
    {
        items.Add(new PriorityQueueItem(value, priority));
    }

    public string Dequeue()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        int maxPriority = items.Max(i => i.Priority);
        int index = items.FindIndex(i => i.Priority == maxPriority);
        string result = items[index].Value;
        items.RemoveAt(index);
        return result;
    }
}

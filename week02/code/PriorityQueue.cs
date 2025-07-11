using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue
{
    private List<(string value, int priority)> queue = new List<(string value, int priority)>();

    public void Enqueue(string value, int priority)
    {
        queue.Add((value, priority));
    }

    public string Dequeue()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        int highestPriority = queue.Max(x => x.priority);
        int index = queue.FindIndex(x => x.priority == highestPriority);
        var item = queue[index];
        queue.RemoveAt(index);
        return item.value;
    }
}

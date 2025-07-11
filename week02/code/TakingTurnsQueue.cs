using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<(string name, int turns)> queue = new Queue<(string name, int turns)>();

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue((name, turns));
    }

    public string GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var person = queue.Dequeue();

        if (person.turns == 0 || person.turns < 0)
        {
            queue.Enqueue((person.name, person.turns)); // Infinite turns
        }
        else if (person.turns > 1)
        {
            queue.Enqueue((person.name, person.turns - 1)); // One turn used
        }

        return person.name;
    }
}

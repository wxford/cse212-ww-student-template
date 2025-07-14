using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    public void AddPerson(string name, int numTurns)
    {
        queue.Enqueue(new Person(name, numTurns));
    }

    public string GetNextPerson()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        Person person = queue.Dequeue();

        if (person.TurnsLeft > 1)
        {
            person.TurnsLeft--;
            queue.Enqueue(person);
        }
        else if (person.TurnsLeft <= 0)
        {
            // Infinite turns
            queue.Enqueue(person);
        }

        return person.Name;
    }
}

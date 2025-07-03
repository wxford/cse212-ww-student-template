using System;
using System.Collections.Generic;

public class Arrays
{
    // -----------------------------------------
    // Part 1: MultiplesOf
    // -----------------------------------------

    /*
     PLAN:
     1. Create an array of size "count".
     2. Use a loop to fill in each index of the array.
     3. At each index i, store the value: start * (i + 1).
     4. Return the filled array.
    */
    public static double[] MultiplesOf(double start, int count)
    {
        double[] result = new double[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }

        return result;
    }

    // -----------------------------------------
    // Part 2: RotateListRight
    // -----------------------------------------

    /*
     PLAN:
     1. Find the index to split the list by: data.Count - amount.
     2. Use GetRange to get the last 'amount' elements.
     3. Use GetRange to get the rest of the elements before that.
     4. Create a new list by combining both ranges: rotated = lastPart + firstPart.
     5. Clear the original list and use AddRange to update it.
    */
    public static void RotateListRight(List<int> data, int amount)
    {
        int splitIndex = data.Count - amount;

        List<int> lastPart = data.GetRange(splitIndex, amount);
        List<int> firstPart = data.GetRange(0, splitIndex);

        data.Clear(); // clear original list
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}

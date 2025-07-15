using System;
using System.Collections.Generic;
using System.IO;

public class SetsAndMaps
{
    // Problem 1: Find Pairs
    public static List<string> FindPairs(List<string> words)
    {
        var result = new List<string>();
        var set = new HashSet<string>();

        foreach (var word in words)
        {
            string reverse = new string(new[] { word[1], word[0] });
            if (set.Contains(reverse))
            {
                result.Add($"{word} & {reverse}");
            }
            set.Add(word);
        }

        return result;
    }

    // Problem 2: Summarize Degrees from CSV
    public static Dictionary<string, int> SummarizeDegrees(string filePath)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(',');
            if (parts.Length >= 5)
            {
                string degree = parts[4].Trim();
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }
        return degrees;
    }

    // Problem 3: Check if two strings are anagrams
    public static bool IsAnagram(string word1, string word2)
    {
        Dictionary<char, int> Normalize(string input)
        {
            var dict = new Dictionary<char, int>();
            foreach (char c in input.ToLower())
            {
                if (char.IsWhiteSpace(c)) continue;
                if (!dict.ContainsKey(c))
                    dict[c] = 1;
                else
                    dict[c]++;
            }
            return dict;
        }

        var d1 = Normalize(word1);
        var d2 = Normalize(word2);

        if (d1.Count != d2.Count)
            return false;

        foreach (var kvp in d1)
        {
            if (!d2.ContainsKey(kvp.Key) || d2[kvp.Key] != kvp.Value)
                return false;
        }

        return true;
    }
}

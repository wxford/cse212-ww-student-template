using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public class SetsAndMaps
{
    // Problem 1: Find Pairs with Sets
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            // Skip words with identical letters (e.g., "aa")
            if (word[0] == word[1])
                continue;

            // Create the reversed word
            string reversed = word[1].ToString() + word[0].ToString();

            // If reversed word is in the set, we found a symmetric pair
            if (wordSet.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                wordSet.Add(word);
            }
        }

        return result.ToArray();
    }

    // Problem 2: Degree Summary
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degreeCounts = new Dictionary<string, int>();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines.Skip(1)) // Skip header if present
            {
                string[] columns = line.Split(',');
                if (columns.Length >= 4)
                {
                    string degree = columns[3].Trim();
                    if (!string.IsNullOrEmpty(degree))
                    {
                        if (degreeCounts.ContainsKey(degree))
                        {
                            degreeCounts[degree]++;
                        }
                        else
                        {
                            degreeCounts[degree] = 1;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error reading file: {ex.Message}");
        }

        return degreeCounts;
    }

    // Problem 3: Anagrams
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If lengths differ, they can't be anagrams
        if (word1.Length != word2.Length)
            return false;

        // Use dictionary to count characters in word1
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char c in word1)
        {
            charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
        }

        // Subtract counts for word2
        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c))
                return false;
            charCount[c]--;
            if (charCount[c] == 0)
                charCount.Remove(c);
        }

        // If dictionary is empty, words are anagrams
        return charCount.Count == 0;
    }

    // Problem 5: Earthquake JSON Data
    public static string[] EarthquakeDailySummary()
    {
        List<string> result = new List<string>();
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
                string jsonResponse = client.GetStringAsync(url).Result;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                FeatureCollection data = JsonSerializer.Deserialize<FeatureCollection>(jsonResponse, options);

                if (data?.features != null)
                {
                    foreach (var feature in data.features)
                    {
                        string place = feature.properties?.place ?? "Unknown Location";
                        double magnitude = feature.properties?.mag ?? 0.0;
                        result.Add($"{place} - Mag {magnitude:F2}");
                    }
                }
                else
                {
                    Debug.WriteLine("No features found in JSON data or data is null.");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching or parsing earthquake data: {ex.Message}");
        }

        return result.ToArray();
    }
}
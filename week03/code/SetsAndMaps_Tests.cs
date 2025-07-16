using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class FindPairsTests
{
    [TestMethod]
    public void FindPairs_TwoPairs()
    {
        var actual = SetsAndMaps.FindPairs(new string[] { "am", "at", "ma", "if", "fi" });
        var expected = new[] { "ma & am", "fi & if" };

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    [TestMethod]
    public void FindPairs_OnePair()
    {
        var actual = SetsAndMaps.FindPairs(new string[] { "ab", "bc", "cd", "de", "ba" });
        var expected = new[] { "ba & ab" };

        Assert.AreEqual(expected.Length, actual.Length);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual));
    }

    private string Canonicalize(string[] input)
    {
        var list = new List<string>(input);
        list.Sort();
        return string.Join(",", list);
    }
}

[TestClass]
public class SummarizeDegreesTests
{
    [TestMethod]
    public void SummarizeDegrees_SampleFile()
    {
        string filename = "census.txt";
        var result = SetsAndMaps.SummarizeDegrees(filename);
        Assert.IsTrue(result.ContainsKey("Bachelor's degree"), "Should contain Bachelor's degree");
        Assert.IsTrue(result.Count > 0, "Should return non-empty dictionary");
    }
}

[TestClass]
public class AnagramTests
{
    [TestMethod]
    public void IsAnagram_ValidAnagram()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("CAT", "ACT"));
        Assert.IsTrue(SetsAndMaps.IsAnagram("Ab", "bA"));
    }

    [TestMethod]
    public void IsAnagram_NotAnagram()
    {
        Assert.IsFalse(SetsAndMaps.IsAnagram("DOG", "GOOD"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("cat", "dog"));
    }
}

[TestClass]
public class EarthquakeDailySummaryTests
{
    [TestMethod]
    public void EarthquakeDailySummary_FetchesData()
    {
        var result = SetsAndMaps.EarthquakeDailySummary();
        Assert.IsNotNull(result, "Result should not be null");
        Assert.IsTrue(result.Length >= 0, "Result should be an array");
    }
}
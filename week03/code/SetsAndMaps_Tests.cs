using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FindPairsTests
{
    [TestMethod]
    public void FindPairs_TwoPairs()
    {
        var actual = SetsAndMaps.FindPairs(new List<string> { "am", "at", "ma", "if", "fi" });
        var expected = new[] { "ma & am", "fi & if" };

        Assert.AreEqual(expected.Length, actual.Count);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual.ToArray()));
    }

    [TestMethod]
    public void FindPairs_OnePair()
    {
        var actual = SetsAndMaps.FindPairs(new List<string> { "ab", "bc", "cd", "de", "ba" });
        var expected = new[] { "ba & ab" };

        Assert.AreEqual(expected.Length, actual.Count);
        Assert.AreEqual(Canonicalize(expected), Canonicalize(actual.ToArray()));
    }

    private string[] Canonicalize(string[] input)
    {
        var list = new List<string>(input);
        list.Sort();
        return list.ToArray();
    }
}

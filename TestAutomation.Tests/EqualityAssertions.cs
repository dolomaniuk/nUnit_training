using NUnit.Framework;

namespace TestAutomation.Tests;

[TestFixture]
public class EqualityAssertions
{
    [Test]
    public void AreEqueal()
    {
        Assert.AreEqual("true", "true");
    }

    [Test]
    public void AreEquealNumberWithinTolerance()
    {
        Assert.AreEqual(2, 2, .5);
    }

    [Test]
    // [Sequential] 
    [Pairwise]
    [NonParallelizable]
    public void AreEqualArrays([Values(new int[] { 1, 2, 3 }, new int[] { 2, 3, 4 })] int[] expected,
        [Values(new int[] { 1, 2, 3 }, new int[] { 6, 4, 4 })] int[] actual)
    {
        // var expected = new int[] { 1, 2, 3 };
        // var actual = new int[] { 1, 3, 2 };
        // Assert.AreEqual(expected, actual);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AreEqualObjects()
    {
        var obj1 = new object();
        var obj2 = new object();
        var AretheyEqual = obj1.Equals(obj2);
        Assert.IsTrue(AretheyEqual);
    }

    [Test]
    public void IsEmptyString()
    {
        var str = string.Empty;
        Assert.IsEmpty(str);
    }

    [Test]
    public void CompareRelativeValues()
    {
        Assert.GreaterOrEqual(3, 2);
    }
}
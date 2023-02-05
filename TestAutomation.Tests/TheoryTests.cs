using NUnit.Framework;

namespace TestAutomation.Tests;

public class TheoryTests
{
    [Datapoints]
    public string[] InvalidValues = new[] { null, string.Empty };

    [Datapoints]
    public string[] PositiveValues = new[] { "good" };

    [Datapoints]
    public string[] NegativeValues = new[] { "Bad" };

    [Datapoints] 
    public double[] values = new[] { 0.0, 1.0, -1.0, 42.0 };

    private bool FunctionUnderTest(string value)
    {
        return value.ToLower().Equals(value);
    }

    [Theory]
    public void PositiveTest(string value)
    {
        Assume.That(!string.IsNullOrEmpty(value));

        var result = FunctionUnderTest(value);

        Assert.True(result);
    }

    [Theory]
    public void PassingPositiveTest(string value)
    {
        Assume.That(!string.IsNullOrEmpty(value));
        Assume.That(!NegativeValues.Contains(value));

        var result = FunctionUnderTest(value);

        Assert.True(result);
    }

    [Theory]
    public void SquareRootDefenition(double num)
    {
        Assume.That(num >= 0.0);

        double sqrt = Math.Sqrt(num);
        Assert.That(sqrt >= 0.0);
        Assert.That(sqrt * sqrt, Is.EqualTo(num).Within(0.000001));
    }
}
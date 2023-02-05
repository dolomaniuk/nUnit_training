using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TestAutomation.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown()
    {
        TestContext.WriteLine($"{TestContext.CurrentContext.Result.Outcome.Status}");
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
        {
            TestContext.WriteLine($"{TestContext.CurrentContext.Result.Outcome.Label}");
            TestContext.WriteLine($"{TestContext.CurrentContext.Result.Outcome.Site}");
        }
    }

    [Test]
    public async Task MyFirstNUnitTest()
    {
        Assert.Pass();
    }

    [Test]
    public static void ThisIsStaticTest()
    {
        Assert.That(Assert.Pass, Throws.TypeOf<AssertionException>());
    }
}
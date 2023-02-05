using NUnit.Framework;

namespace TestAutomation.Tests;

[TestFixture]
[Parallelizable]
public class AdvancedOptions
{
    [Test]
    [Order(3)]
    [Explicit("reason")]
    public void UsingWarnings()
    {
        bool isProcessed = false;
        Warn.Unless(isProcessed, Is.EqualTo(true)
            .After(20).Seconds.PollEvery(10).Seconds);
        Console.WriteLine("still going");
    }

    [Test]
    [Order(0)]
    public void AssertPastThrowsException()
    {
        Assert.That(Assert.Fail, Throws.TypeOf<AssertionException>());
    }

    [Test]
    public void Assumption(
        [ValueSource(typeof(TestData), nameof(TestData.CurrencyString))]string price
        )
    {
        Assume.That(price, Is.EqualTo("88.00"));
    }

    [Test]
    [Order(2)]
    public void AssumingThenAssert()
    {
        var customSettingEnabled = true;
        Assume.That(customSettingEnabled, Is.True, "we haven't guest");
        // test action here
        Assert.That("a value", Is.EqualTo("this value"));
    }

    [Test]
    [Order(1)]
    public void MultipleAssertions()
    {
        var customSettingEnabled = true;
        Assert.Multiple(() =>
        {
            Assert.That(customSettingEnabled, Is.True, "we haven't guest");
            // test action here
            Assert.That("a value", Is.EqualTo("this value"));
        });
    }
}
using System;
using FluentAssertions;

using Xunit;

namespace BBUnit.Runtime.Tests;

public class TestCaseDiscoveryContextTestSuite : ITestSuite<TestCaseDiscoveryContext>
{
    public TestCaseDiscoveryContext It { get; init; }

    [Fact]
    [TestScenario]
    public void LoadFromAssembly()
    {
        var ctx = TestCaseDiscoveryContext
            .Empty
            .With(typeof(TestCaseDiscoveryContextTestSuite).Assembly);

        var caseCollection = TestCaseCollection
            .FromDiscoveryContext(ctx);

        caseCollection.Cases.Should().NotBeEmpty();
    }
}

using System;
using System.Collections.Immutable;

namespace BBUnit.Runtime;

public record class TestExecutionContext(
    IImmutableList<TestSuite> TestSuites,
    IImmutableList<TestFixture> TestFixtures
)
{
    public static TestExecutionContext Empty { get; }
        = new TestExecutionContext(
            ImmutableList<TestSuite>.Empty,
            ImmutableList<TestFixture>.Empty);

    public TestExecutionContext With(TestSuite suite)
        => this with { TestSuites = TestSuites.Add(suite) };

    public TestExecutionContext With(TestFixture fixture)
        => this with { TestFixtures = TestFixtures.Add(fixture) };
}

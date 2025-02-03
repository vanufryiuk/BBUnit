using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

using BBUnit.Internal;

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

    public TestExecutionContext With(Assembly asm)
    {
        var suites = new List<TestSuite>();
        var fixtures = new List<TestFixture>();

        foreach (var type in asm.ExportedTypes)
        {
            if (!type.IsAssignableTo(typeof(ITestingAbstraction)))
            {
                // optimization: no need to proceed if it is not a testing abstraction
                continue;
            }

            if (type.IsAssignableTo(typeof(ITestSuite)))
            {
                suites.Add(TestSuite.FromDefinition(type));
            }

            if (type.IsAssignableTo(typeof(ITestFixture)))
            {
                fixtures.Add(type.ToTestFixture());
            }
        }

        return this with
        {
            TestSuites = TestSuites.AddRange(suites),
            TestFixtures = TestFixtures.AddRange(fixtures)
        };
    }
}

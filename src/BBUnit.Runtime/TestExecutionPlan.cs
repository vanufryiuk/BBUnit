using System.Collections.Immutable;

namespace BBUnit.Runtime;

public class TestExecutionPlan
{
    public IImmutableList<TestCase> Cases { get; } = ImmutableList<TestCase>
        .Empty.Add(new TestCase());
}

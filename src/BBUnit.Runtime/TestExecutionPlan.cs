using System;
using System.Collections.Immutable;

namespace BBUnit.Runtime;

public class TestExecutionPlan
{
    public static TestExecutionPlan FromContext(TestExecutionContext ctx)
    {
        throw new NotImplementedException();
    }

    public IImmutableList<TestCase> Cases { get; } = ImmutableList<TestCase>
        .Empty;

}

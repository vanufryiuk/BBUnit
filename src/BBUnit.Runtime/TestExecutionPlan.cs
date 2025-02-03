using System;
using System.Collections.Immutable;

namespace BBUnit.Runtime;

public record class TestExecutionPlan (
    IImmutableList<TestCase> Cases)
{
    public static TestExecutionPlan FromContext(TestExecutionContext ctx)
    {
        throw new NotImplementedException();
    }
}

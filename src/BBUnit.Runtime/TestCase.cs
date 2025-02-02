using System.Collections.Immutable;
using System.Linq;

namespace BBUnit.Runtime;

public class TestCase
{
    public string Name { get; }

    public TestSuite Suite { get; }

    public TestFixture Fixture { get; }

    public TestScenario Scenario { get; }

    public IImmutableList<TestPrecondition> CasePreconditions { get; }

    public TestCase(
        TestSuite suite,
        TestFixture fixture,
        TestScenario scenario,
        IImmutableList<TestPrecondition> casePreconditions
    )
    {
        this.Suite = suite;
        this.Fixture = fixture;
        this.Scenario = scenario;
        this.CasePreconditions = casePreconditions;

        this.Name = string.Join("_", new[] { scenario.Name }.Concat(casePreconditions.Select(p => p.Name)));
    }
}

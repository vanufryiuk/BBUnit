using System.Collections.Immutable;
using System.Linq;

namespace BBUnit.Runtime;

public record class TestCase(
    string Name,
    TestSuite Suite,
    TestFixture Fixture,
    TestScenario Scenario,
    IImmutableList<TestPrecondition> CasePreconditions)
{
    public TestCase (
        TestSuite Suite,
        TestFixture Fixture,
        TestScenario Scenario,
        IImmutableList<TestPrecondition> CasePreconditions)
    : this (
        string.Join("_", new[] { Scenario.Name }.Concat(CasePreconditions.Select(p => p.Name))),
        Suite,
        Fixture,
        Scenario,
        CasePreconditions)
    {
    }
}

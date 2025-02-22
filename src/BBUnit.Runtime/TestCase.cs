using System;
using System.Collections.Immutable;
using System.Linq;

namespace BBUnit.Runtime;

public record class TestCase(
    string Name,
    TestSuite Suite,
    TestFixture Fixture,
    TestScenario Scenario,
    IImmutableList<Type> CasePreconditionDefinitions)
{
    public TestCase (
        TestSuite Suite,
        TestFixture Fixture,
        TestScenario Scenario,
        IImmutableList<Type> CasePreconditionDefinitions)
    : this (
        string.Join("_", new[] { Scenario.Name }.Concat(CasePreconditionDefinitions.Select(p => p.Name))),
        Suite,
        Fixture,
        Scenario,
        CasePreconditionDefinitions)
    {
    }
}

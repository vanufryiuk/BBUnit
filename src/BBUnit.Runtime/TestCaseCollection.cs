using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;

namespace BBUnit.Runtime;

public record class TestCaseCollection(IImmutableList<TestCase> Cases)
{
    public static TestCaseCollection FromDiscoveryContext(TestCaseDiscoveryContext ctx)
    {
        var cases = new List<TestCase>();

        foreach (var suite in ctx.TestSuites)
        {
            var appropriateFixtures = ctx.TestFixtures
                .Where(f =>
                    suite.Contract.IsAssignableFrom(f.Target) &&
                    !f.NotForDefinitions.Contains(suite.Definition) &&
                    !suite.NotForDefinitions.Contains(f.Definition))
                .ToList();

            if (appropriateFixtures.Count < 1)
            {
                appropriateFixtures.Add(TestFixture
                    .FromDefinition(typeof(DefaultTestFixture)));
            }

            foreach (var scenario in suite.Scenarios)
                {
                    foreach (var fixture in appropriateFixtures)
                    {
                        if (scenario.NotForDefinitions.Contains(fixture.Definition))
                        {
                            continue;
                        }

                        var casePreconditions = suite
                            .ProvidedThatDefinitions
                            .AddRange(scenario.ProvidedThatDefinitions);

                        cases.Add(new TestCase(
                            suite,
                            fixture,
                            scenario,
                            casePreconditions));

                        foreach (var corner in suite.EvenIfDefinitions)
                        {
                            cases.Add(new TestCase(
                                suite,
                                fixture,
                                scenario,
                                casePreconditions.Add(corner)));
                        }

                        foreach (var corner in scenario.EvenIfDefinitions)
                        {
                            cases.Add(new TestCase(
                                suite,
                                fixture,
                                scenario,
                                casePreconditions.Add(corner)));
                        }
                    }
                }
        }

        return new TestCaseCollection(cases.ToImmutableList());
    }
}

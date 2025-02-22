using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace BBUnit.Runtime;

public record class TestSuite(
    string Name,
    Type Contract,
    IImmutableList<TestScenario> Scenarios,
    bool Skip,
    IImmutableList<Type> SkipForDefinitions,
    IImmutableList<Type> NotForDefinitions,
    IImmutableList<string> SharedResources,
    IImmutableList<Type> ProvidedThatDefinitions,
    IImmutableList<Type> EvenIfDefinitions,
    Type Definition)
{
    public static TestSuite FromDefinition(Type definition)
    {
        var contract = definition
            .FindInterfaces(
                (t, _) => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(ITestSuite<>),
                default)
            .Select(t => t.GenericTypeArguments[0])
            .Single();

        var attrs = definition
            .GetCustomAttributes();

        var skip = false;
        var skipForDefs = new List<Type>();
        var notForDefs = new List<Type>();
        var sharedResources = new List<string>();
        var providedThatDefs = new List<(uint? Order, Type Definition)>();
        var evenIfDefs = new List<Type>();

        foreach (var attr in attrs)
        {
            switch (attr)
            {
                case SkipAttribute:
                    skip = true;
                    continue;
                case SkipForAttribute skipForAttr:
                    skipForDefs.AddRange(skipForAttr.Targets);
                    continue;
                case NotForAttribute notForAttr:
                    notForDefs.AddRange(notForAttr.Targets);
                    continue;
                case CriticalSectionsAttribute csAttr:
                    sharedResources.AddRange(csAttr.SharedResources);
                    continue;
                case ProvidedThatAttribute ptAttr:
                    providedThatDefs.Add((ptAttr.Order, ptAttr.Precondition));
                    continue;
                case EvenIfAttribute eiAttr:
                    evenIfDefs.Add(eiAttr.Precondition);
                    continue;
                default:
                    continue;
            }
        }

        var scenarios = definition
            .FindMembers(
                MemberTypes.Method,
                BindingFlags.Instance | BindingFlags.Public,
                (m, _) => m.IsDefined(typeof(TestScenarioAttribute)),
                null)
            .OfType<MethodInfo>()
            .Select(m => TestScenario.FromDefinition(m));

        return new TestSuite(
            definition.Name,
            contract,
            scenarios.ToImmutableList(),
            skip,
            skipForDefs.ToImmutableList(),
            notForDefs.ToImmutableList(),
            sharedResources.ToImmutableList(),
            providedThatDefs
                .OrderBy(it => it.Order)
                .Select(it => it.Definition)
                .ToImmutableList(),
            evenIfDefs.ToImmutableList(),
            definition);
    }
}

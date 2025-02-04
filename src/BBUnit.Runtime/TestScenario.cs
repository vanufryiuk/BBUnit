using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace BBUnit.Runtime;

public record class TestScenario(
    string Name,
    IImmutableList<TestScenarioParameter> Parameters,
    bool Skip,
    IImmutableList<Type> SkipForDefinitions,
    IImmutableList<Type> NotForDefinitions,
    IImmutableList<string> SharedResources,
    IImmutableList<Type> ProvidedThatDefinitions,
    IImmutableList<Type> EvenIfDefinitions,
    string FilePath,
    int LineNumber,
    MethodInfo Definition)
{
    public static TestScenario FromDefinition(MethodInfo definition)
    {
        var attrs = definition
            .GetCustomAttributes();

        var skip = false;
        var skipForDefs = new List<Type>();
        var notForDefs = new List<Type>();
        var sharedResources = new List<string>();
        var providedThatDefs = new List<(uint? Order, Type Definition)>();
        var evenIfDefs = new List<Type>();
        string filePath = string.Empty;
        int lineNumber = 0;

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
                case TestScenarioAttribute tsAttr:
                    filePath = tsAttr.FilePath;
                    lineNumber = tsAttr.LineNumber;
                    continue;
                default:
                    continue;
            }
        }

        var parameters = definition
            .GetParameters()
            .Select(m => TestScenarioParameter.FromDefinition(m))
            .ToImmutableList();

        return new TestScenario(
            definition.Name,
            parameters,
            skip,
            skipForDefs.ToImmutableList(),
            notForDefs.ToImmutableList(),
            sharedResources.ToImmutableList(),
            providedThatDefs
                .OrderBy(it => it.Order)
                .Select(it => it.Definition)
                .ToImmutableList(),
            evenIfDefs.ToImmutableList(),
            filePath,
            lineNumber,
            definition);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace BBUnit.Runtime;

public record class TestFixture(
    string Name,
    Type Target,
    bool Skip,
    IImmutableList<Type> SkipForDefinitions,
    IImmutableList<Type> NotForDefinitions,
    IImmutableList<string> SharedResources,
    Type Definition)
{
    public static TestFixture FromDefinition(Type definition)
    {
        var target = definition
            .FindInterfaces(
                (t, _) => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(ITestFixture<>),
                default)
            .Select(t => t.GenericTypeArguments[0])
            .Single();

        var attrs = definition
            .GetCustomAttributes();

        var skip = false;
        var skipForDefs = new List<Type>();
        var notForDefs = new List<Type>();
        var sharedResources = new List<string>();

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
                default:
                    continue;
            }
        }

        return new TestFixture(
            definition.Name,
            target,
            skip,
            skipForDefs.ToImmutableList(),
            notForDefs.ToImmutableList(),
            sharedResources.ToImmutableList(),
            definition);
    }
}

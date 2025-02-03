using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace BBUnit.Runtime;

public record class TestSuite(
    string Name,
    Type Contract,
    bool Skip,
    IImmutableList<Type> SkipForDefinitions,
    IImmutableList<Type> NotForDefinitions,
    IImmutableList<string> SharedResources,
    Type Definition)
{
    public static TestSuite FromDefinition(Type definition)
    {
        var contract = definition
            .FindInterfaces(
                (t, _) => t.GetGenericTypeDefinition() == typeof(ITestSuite<>),
                default)
            .Select(t => t.GenericTypeArguments[0])
            .Single();

        var suiteAttrs = definition
            .GetCustomAttributes();

        var skip = false;
        var skipForDefs = new List<Type>();
        var notForDefs = new List<Type>();
        var sharedResources = new List<string>();

        foreach (var attr in suiteAttrs)
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

        var methods = definition
            .GetMethods(BindingFlags.Instance | BindingFlags.Public);

        foreach (var method in methods)
        {
            var methodAttrs = method.GetCustomAttributes();
        }

        return new TestSuite(
            definition.Name,
            contract,
            skip,
            skipForDefs.ToImmutableList(),
            notForDefs.ToImmutableList(),
            sharedResources.ToImmutableList(),
            definition);
    }
}

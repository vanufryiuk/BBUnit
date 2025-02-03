using System;
using System.Linq;
using System.Reflection;

namespace BBUnit.Runtime;

public static class TypeExtensions
{
    public static TestSuite ToTestSuite(this Type self)
    {
        var contract = self
            .FindInterfaces(
                (t, _) => t.GetGenericTypeDefinition() == typeof(ITestSuite<>),
                default)
            .Select(t => t.GenericTypeArguments[0])
            .Single();

        var backdoors = self
            .FindMembers(
                MemberTypes.Property,
                BindingFlags.Instance | BindingFlags.Public,
                (m, _) => m.IsDefined(typeof(BackdoorAttribute), false),
                default)
            .OfType<PropertyInfo>();

        var suite = new TestSuite();

        return suite;
    }

    public static TestFixture ToTestFixture(this Type self)
    {
        var targets = self
            .FindInterfaces(
                (t, _) => t.GetGenericTypeDefinition() == typeof(ITestFixture<>),
                default)
            .Select(t => t.GenericTypeArguments[0]);

        var fixture = new TestFixture();

        return fixture;
    }
}

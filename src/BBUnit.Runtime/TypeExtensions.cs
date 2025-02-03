using System;
using System.Linq;
using System.Reflection;

namespace BBUnit.Runtime;

public static class TypeExtensions
{
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

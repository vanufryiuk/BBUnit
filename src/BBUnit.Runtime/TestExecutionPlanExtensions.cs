using System;
using System.Linq;
using System.Reflection;

using BBUnit.Internal;

namespace BBUnit.Runtime;

public static class TestExecutionPlanExtensions
{
    private static Type TestFixtureIface = typeof(ITestFixture<>);

    private static Type TestSuiteIface = typeof(ITestSuite<>);

    private static Type BackdoorAttributeType = typeof(BackdoorAttribute);

    public static TestExecutionPlan WithAssembly(this TestExecutionPlan self, Assembly asm)
        => asm.DefinedTypes.Aggregate(self, (plan, type) =>
        {
            if (!type.IsAssignableTo(typeof(ITestingAbstraction)))
            {
                // optimization: no need to proceed if it is not a testing abstraction
                return plan;
            }

            if (type.IsAssignableTo(typeof(ITestSuite)))
            {
                return plan.WithTestSuiteDefinition(type);
            }

            if (type.IsAssignableTo(typeof(ITestFixture)))
            {
                return plan.WithTestFixtureDefinition(type);
            }

            return plan;
        });

    public static TestExecutionPlan WithTestSuiteDefinition(this TestExecutionPlan self, Type tsd)
    {
        var contract = tsd
            .FindInterfaces(
                (t, expected) => t.GetGenericTypeDefinition() == (Type)expected!,
                TestSuiteIface)
            .Select(t => t.GenericTypeArguments[0])
            .Single();

        var backdoors = tsd
            .FindMembers(
                MemberTypes.Property,
                BindingFlags.Instance | BindingFlags.Public,
                (m, attr) => m.IsDefined((Type)attr!, false),
                BackdoorAttributeType)
            .;

        var suite = new TestSuite();
    }

    public static TestExecutionPlan WithTestFixtureDefinition(this TestExecutionPlan self, Type tfd)
    {
        throw new NotImplementedException();
    }
}

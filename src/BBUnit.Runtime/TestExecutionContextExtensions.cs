using System.Linq;
using System.Reflection;

using BBUnit.Internal;

namespace BBUnit.Runtime;

public static class TestExecutionContextExtensions
{
    public static TestExecutionContext WithAssembly(this TestExecutionContext self, Assembly asm)
        => asm.DefinedTypes.Aggregate(self, (plan, type) =>
        {
            if (!type.IsAssignableTo(typeof(ITestingAbstraction)))
            {
                // optimization: no need to proceed if it is not a testing abstraction
                return plan;
            }

            if (type.IsAssignableTo(typeof(ITestSuite)))
            {
                return plan.With(type.ToTestSuite());
            }

            if (type.IsAssignableTo(typeof(ITestFixture)))
            {
                return plan.With(type.ToTestFixture());
            }

            return plan;
        });
}

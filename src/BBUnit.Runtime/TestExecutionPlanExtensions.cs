using System;
using System.Reflection;

namespace BBUnit.Runtime;

public static class TestExecutionPlanExtensions
{
    public static TestExecutionPlan WithAssembly(this TestExecutionPlan self, Assembly asm)
    {
        return self;
    }
}

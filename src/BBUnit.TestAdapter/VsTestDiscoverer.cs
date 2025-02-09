using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Loader;

using BBUnit.Runtime;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace BBUnit.TestAdapter;

[FileExtension(".dll")]
[Category("managed")]
[DefaultExecutorUri(VsTestExecutor.StrUri)]
public class VsTestDiscoverer : ITestDiscoverer
{
    public void DiscoverTests(
        IEnumerable<string> sources,
        IDiscoveryContext discoveryContext,
        IMessageLogger logger,
        ITestCaseDiscoverySink discoverySink)
    {
        var asmCtx = AssemblyLoadContext.Default;

        foreach (var source in sources)
        {
            var asm = asmCtx
                .LoadFromAssemblyPath(source)!;

            var ctx = TestCaseDiscoveryContext
                .Empty.With(asm);

            var plan = TestExecutionPlan
                .FromContext(ctx);

            foreach (var testCase in plan.Cases)
            {
                discoverySink.SendTestCase(
                    testCase.ToVsTestCase(source));
            }
        }
    }
}

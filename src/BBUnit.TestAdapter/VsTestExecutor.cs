using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;

namespace BBUnit.TestAdapter;

[ExtensionUri(StrUri)]
public class VsTestExecutor : ITestExecutor
{
    public const string StrUri = "executor://BBUnit.TestAdapter.VsTestExecutor/";

    public static Uri UriUri { get; } = new(StrUri);

    public void Cancel()
    {
        throw new NotImplementedException();
    }

    public void RunTests(IEnumerable<TestCase>? tests, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        throw new NotImplementedException();
    }

    public void RunTests(IEnumerable<string>? sources, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        throw new NotImplementedException();
    }
}

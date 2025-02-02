using System;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace BBUnit.TestAdapter;

public static class TestCaseExtensions
{
    public static TestCase ToVsTestCase(this Runtime.TestCase self, string source)
    {
        var vsTestCase = new TestCase(
            self.FullyQualifiedName,
            VsTestExecutor.UriUri,
            source
        );

        //vsTestCase.

        return vsTestCase;
    }
}

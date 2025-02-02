using System;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace BBUnit.TestAdapter;

public static class TestCaseExtensions
{
    public static TestCase ToVsTestCase(this Runtime.TestCase self, string source)
    {
        var vsTestCase = new TestCase(
            $"{self.Suite.Name}.{self.Fixture.Name}.{self.Name}",
            VsTestExecutor.UriUri,
            source
        )
        {
            CodeFilePath = self.Scenario.FilePath,
            LineNumber = self.Scenario.LineNumber,
        };

        return vsTestCase;
    }
}

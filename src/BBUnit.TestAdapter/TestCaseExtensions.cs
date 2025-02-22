using System;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace BBUnit.TestAdapter;

public static class TestCaseExtensions
{
    private static readonly TestProperty ManagedType = TestProperty.Find("ManagedType")!;
    private static readonly TestProperty ManagedMethod = TestProperty.Find("ManagedMethod")!;

    public static TestCase ToVsTestCase(this Runtime.TestCase self, string source)
    {
        var result = new TestCase(
            $"{self.Suite.Name}.{self.Fixture.Name}.{self.Name}",
            VsTestExecutor.UriUri,
            source
        )
        {
            CodeFilePath = self.Scenario.FilePath,
            LineNumber = self.Scenario.LineNumber,
        };

        //result.SetPropertyValue(ManagedType, self.Suite.Definition.FullName);
        //result.SetPropertyValue(ManagedMethod, self.Scenario.Definition.Name);

        return result;
    }
}

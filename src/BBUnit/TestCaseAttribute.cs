using System;
using System.Runtime.CompilerServices;

namespace BBUnit;

[AttributeUsage(AttributeTargets.Method)]
public class TestCaseAttribute(
    [CallerFilePath] string filePath = "",
    [CallerLineNumber] int lineNumber = 0
) : Attribute
{
    public string FilePath { get; } = filePath;
    public int LineNumber { get; } = lineNumber;
}

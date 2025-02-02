using System;
using System.Reflection;

namespace BBUnit.Runtime;

public class TestScenario
{
    public string Name { get; }
    public string FilePath { get; }
    public int LineNumber { get; }
}

using System;
using System.Reflection;

namespace BBUnit.Runtime;

public record class TestScenario(string Name, string FilePath, int LineNumber, MethodInfo Definition);

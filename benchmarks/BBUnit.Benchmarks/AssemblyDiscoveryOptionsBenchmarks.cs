using System;

using BenchmarkDotNet.Attributes;

namespace BBUnit.Benchmarks;

public class AssemblyDiscoveryOptionsBenchmarks
{

    [Benchmark]
    public object DefinedTypes()
    {
        var asm = typeof(AssemblyDiscoveryOptionsBenchmarks).Assembly;
        return asm.DefinedTypes;
    }

    [Benchmark]
    public object ExportedTypes()
    {
        var asm = typeof(AssemblyDiscoveryOptionsBenchmarks).Assembly;
        return asm.ExportedTypes;
    }

    [Benchmark]
    public object GetExportedTypes()
    {
        var asm = typeof(AssemblyDiscoveryOptionsBenchmarks).Assembly;
        return asm.GetExportedTypes();
    }

    [Benchmark]
    public object GetTypes()
    {
        var asm = typeof(AssemblyDiscoveryOptionsBenchmarks).Assembly;
        return asm.GetTypes();
    }
}

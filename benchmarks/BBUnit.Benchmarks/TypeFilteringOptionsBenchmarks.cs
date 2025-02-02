using BenchmarkDotNet.Attributes;

namespace BBUnit.Benchmarks;

public class TypeFilteringOptionsBenchmarks
{
    [Benchmark]
    public object IsDefinedNonGeneric()
    {
        return typeof(MarkedWithNonGenericAttr)
            .IsDefined(typeof(NonGenericAttributeAttribute), false);
    }

    [Benchmark]
    public object IsDefinedGeneric()
    {
        return typeof(MarkedWithGenericAttr)
            .IsDefined(typeof(GenericAttributeAttribute<object>), false);
    }

    [Benchmark]
    public object IsAssignableFromNonGeneric()
    {
        return typeof(INonGenericInterface)
            .IsAssignableFrom(typeof(MarkedWithNonGenericIface));
    }

    [Benchmark]
    public object IsAssignableFromGeneric()
    {
        return typeof(IGenericInterface<object>)
            .IsAssignableFrom(typeof(MarkedWithGenericIface));
    }

    [Benchmark]
    public object IsAssignableToNonGeneric()
    {
        return typeof(MarkedWithNonGenericIface)
            .IsAssignableTo(typeof(INonGenericInterface));
    }

    [Benchmark]
    public object IsAssignableToGeneric()
    {
        return typeof(MarkedWithGenericIface)
            .IsAssignableTo(typeof(IGenericInterface<object>));
    }
}

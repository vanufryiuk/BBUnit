using System;

namespace BBUnit.Internal;

internal static class Backdoor
{
    private static Func<Type, object, object?>? GetBackdoor { get; set; }

    internal static object? Get(Type backdoorType, object target)
        => GetBackdoor!(backdoorType, target);

    internal static void SetBackdoorGetter(Func<Type, object, object?> getter)
    {
        GetBackdoor = getter;
    }
}

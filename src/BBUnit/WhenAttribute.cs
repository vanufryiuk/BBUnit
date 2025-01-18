namespace BBUnit;

/// <summary>
/// Applies the given precondition to the testing context before test(s)
/// execution.
/// </summary>
/// <typeparam name="TPrecondition">Precondition to apply before test(s)
/// execution.</typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class WhenAttribute<TPrecondition> : Attribute
where TPrecondition : ITestPrecondition
{
    /// <summary>
    /// If you use more than one WhenAttribute, you may need to apply them in a
    /// specific order.
    /// </summary>
    /// <remarks>
    /// You should consider that WhenAttribute preconditions are always applied
    /// before CornerCaseAttribute ones.
    /// </remarks>
    public uint Order { get; set; }
}

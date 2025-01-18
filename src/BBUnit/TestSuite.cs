namespace BBUnit;

/// <summary>
///     Base class of a test collection.
/// </summary>
/// <typeparam name="TContract">
///     Contract (class or interface) of the test target.
/// </typeparam>
/// <remarks>
///     <para>
///         Any <see cref="TestSuite{TContract}" /> child (like any other
///         <see cref="ITestSuite{TContract}"/> implementation) is treated as a
///         test collection. <typeparamref name="TContract"/> here is a contract
///         (class or interface) of a test target.
///     </para>
///     <para>
///         Use <see cref="It" /> property to access the test target instance.
///     </para>
///     <para>
///         Consider <see cref="ITestSuite{TContract}"/> interface instead if
///         you need test suite inheritance.
///     </para>
/// </remarks>
public abstract class TestSuite<TContract>
where TContract : class
{
    /// <inheritdoc cref="ITestSuite{TContract}.It"/>
    public required TContract It { get; init; }
}

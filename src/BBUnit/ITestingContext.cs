namespace BBUnit;

/// <summary>
///     Interface of a testing context - an abstraction intended to separate
///     test initialization logic from test logic itself.
/// </summary>
/// <typeparam name="TContract">
///     Contract (class or interface) of the test target.
/// </typeparam>
/// <remarks>
///     <para>
///         Any <see cref="ITestSuite{TContract}" /> implementation is treated
///         as a test collection. <typeparamref name="TContract"/> here is a
///         contract (<c>class</c> or <c>interface</c>) of a test target.
///     </para>
///     <para>
///         Use <see cref="It" /> property to access the test target instance.
///     </para>
///     <para>
///         Consider <see cref="TestSuite{TContract}"/> class instead if you
///         don't need test suite inheritance.
///     </para>
/// </remarks>
public interface ITestingContext<TTarget>
where TTarget : class
{
    ValueTask<ITargetSetup> SetupTargetAsync(ITargetSetup initialSetup);

    ValueTask<IDataSetup> SetupDataAsync(IDataSetup initialSetup);
}

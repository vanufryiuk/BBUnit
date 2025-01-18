using System;

namespace BBUnit;

/// <summary>
///     Interface of a test collection.
/// </summary>
/// <typeparam name="TContract">
///     Contract (class or interface) of the test target.
/// </typeparam>
/// <remarks>
///     <para>
///         Any <see cref="ITestSuite{TContract}"/> implementation is treated as
///         a test collection. <typeparamref name="TContract"/> here is a
///         contract (class or interface) of a test target.
///     </para>
///     <para>
///         Use <see cref="It" /> property to access the test target instance.
///     </para>
///     <para>
///         Consider <see cref="TestSuite{TContract}"/> class instead if you
///         don't need test suite inheritance.
///     </para>
///     <para>
///         By default, BBUnit executes a test suite with no-op
///         <see cref="ITestingContext{TContract}"/>. Create your own
///         <see cref="ITestingContext{TContract}"/> to customize test data or
///         test target setup. See <see cref="ITestingContext{TContract}"/>
///         documentation for details.
///     </para>
///     <para>
///         If you have more than one <see cref="ITestingContext{TContract}"/>,
///         any test suite with appropriate <typeparamref name="TContract"/>
///         will be run once with each of them unless you disable some with
///         <see cref="NotForAttribute{TContext}"/>.
///     </para>
/// </remarks>
public interface ITestSuite<TContract>
where TContract : class
{
    /// <summary>
    ///     Test target instance.
    /// </summary>
    /// <remarks>
    ///     BBUnit runtime is responsible for setting this property, so you may
    ///     want to mark it as <c>required</c> to avoid the compiler warning.
    /// </remarks>
    public TContract It { get; init; }
}

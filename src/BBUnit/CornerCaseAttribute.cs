namespace BBUnit;

/// <summary>
///     Initiates an additional test(s) run with the given precondition applied.
/// </summary>
/// <remarks>
///     <para>
///         The <see cref="CornerCaseAttribute{TPrecondition}" /> attribute is
///         intended to be used when you need to add an additional test run
///         with some specific test target state or some specific test data
///         expecting the same test execution result.
///     </para>
///     <para>
///         Use it on a test method to add an additional run to specific test.
///     </para>
///     <para>
///         Use it on a test suite to add an additional run to each test in the
///         suite.
///     </para>
///     <para>
///         Use it on a test method parameter to apply the precondition to the
///         target parameter exclusively, adding an additional run to the
///         related test.
///     </para>
/// </remarks>
/// <typeparam name="TPrecondition">
///     <see cref="IPrecondition"/> to use for the additional test(s) run.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
public class CornerCaseAttribute<TPrecondition>: Attribute
where TPrecondition: ITestPrecondition
{
}

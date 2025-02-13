// =============================================================================
// Copyright 2025 BBUnit contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the “Software”), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// =============================================================================

namespace BBUnit;

/// <summary>
///     Base class of a test collection.
/// </summary>
/// <typeparam name="TContract">
///     Contract (class or interface) implemented by the test target.
/// </typeparam>
/// <remarks>
///     <para>
///         Any <see cref="TestSuite{T}" /> child (like any other
///         <see cref="ITestSuite{T}"/> implementation) is treated as a test
///         collection. <typeparamref name="TContract"/> here is a contract
///         (class or interface) of a test target. Any public method of a test
///         suite is treated as a test method.
///     </para>
///     <para>
///         Consider <see cref="ITestSuite{TContract}"/> interface instead if
///         you need test suite inheritance.
///     </para>
///     <para>
///         Use <see cref="It" /> property to access the test target instance.
///     </para>
///     <para>
///         Use method parameters to receive test data.
///     </para>
///     <para>
///         Use <see cref="SpecialAttribute"/> if you need some special data for
///         specific parameter.
///     </para>
///     <para>
///         By default, BBUnit executes a test suite with no-op
///         <see cref="ITestStartup{T}"/>. Create your own
///         <see cref="ITestStartup{T}"/> implementation to customize test data
///         or test target setup. See <see cref="ITestStartup{T}"/>
///         documentation for details.
///     </para>
///     <para>
///         If you have more than one <see cref="ITestStartup{T}"/> with
///         TTestTarget appropriate for your test suite, the test suite will be
///         run once for each of these <see cref="ITestStartup{T}"/> unless you
///         disable some with <see cref="NotForAttribute{T}"/>. Not to confuse
///         with <see cref="SkipForAttribute{T}"/> and
///         <see cref="SkipAttribute"/>.
///     </para>
///     <para>
///         An "appropriate" TTestTarget for a test suite is any type which
///         implements or inherits the <typeparamref name="TContract"/> of the
///         test suite. So you'd probably want to use interfaces and classes as
///         contracts and test targets respectively.
///     </para>
///     <para>
///         It is also possible to have a generic <see cref="TestSuite{T}"/>
///         implementation. In this case, BBUnit tries to construct it for each
///         appropriate <see cref="ITestStartup{T}"/> according to the type
///         parameter constraints. As well as for TTestingTarget-TContract
///         matching rules, you are free to disable specific combinations of
///         tests and startups with <see cref="NotForAttribute{T}"/>.
///     </para>
///     <para>
///         If you want to reuse your <see cref="ITestStartup{T}"/>, but some
///         test or event whole test suite requires some minor changes in the
///         <see cref="ITestStartup{T}"/>, you can use
///         <see cref="ProvidedThatAttribute{T}"/> to customize the startup for
///         specific tests or test suites. See
///         <see cref="ProvidedThatAttribute{T}"/> documentation for details.
///     </para>
///     <para>
///         Consider <see cref="EvenIfAttribute{T}"/> if you want to preserve
///         the existing run, but still need an additional run with customized
///         startup. See <see cref="EvenIfAttribute{T}"/> documentation for
///         details.
///     </para>
///     <para>
///         All of your tests are run in parallel by default. Use
///         <see cref="CriticalSectionsAttribute"/> to restrict test parallelism.
///         See <see cref="CriticalSectionsAttribute"/> for details.
///     </para>
/// </remarks>
public abstract class TestSuite<TContract>
where TContract : class
{
    /// <inheritdoc cref="ITestSuite{T}.It"/>
    required public TContract It { get; init; }
}

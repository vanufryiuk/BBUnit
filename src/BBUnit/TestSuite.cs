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
///         Use <see cref="It" /> property to access the test target instance.
///     </para>
///     <para>
///         Use method parameters to receive test data.
///     </para>
///     <para>
///         Consider <see cref="ITestSuite{TContract}"/> interface instead if
///         you need test suite inheritance.
///     </para>
///     <para>
///         By default, BBUnit executes a test suite with no-op
///         <see cref="ITestingContext{T}"/>. Create your own
///         <see cref="ITestingContext{T}"/> implementation to customize test
///         data or test target setup. See <see cref="ITestingContext{T}"/>
///         documentation for details.
///     </para>
///     <para>
///         If you have more than one <see cref="ITestingContext{T}"/> with
///         TTestTarget appropriate for your test suite, the test suite will be
///         run once for each of these <see cref="ITestingContext{T}"/> unless
///         you disable some with <see cref="NotForAttribute{T}"/>. Not to
///         confuse with <see cref="SkipForAttribute{T}"/> and
///         <see cref="SkipAttribute{T}"/>.
///     </para>
///     <para>
///         An "appropriate" TTestTarget for a test suite is any type which
///         implements or inherits the <typeparamref name="TContract"/> of the
///         test suite. So you'd probably want to use interfaces and
///         classes as contracts and test targets respectively.
///     </para>
///     <para>
///         It is also possible to have a generic <see cref="TestSuite{T}"/>
///         implementation. In this case, BBUnit tries to construct it for each
///         appropriate <see cref="ITestingContext{T}"/> according to the type
///         parameter constraints. As well as for TTestingTarget-TContract
///         matching rules, you are free to disable specific combinations of
///         tests and contexts with <see cref="NotForAttribute{T}"/>.
///     </para>
///     <para>
///         If you want to reuse your <see cref="ITestingContext{T}"/>, but some
///         test or event whole test suite requires some minor changes in the
///         <see cref="ITestingContext{T}"/>, you can use
///         <see cref="WhenAttribute{T}"/> to customize the context for specific
///         tests or test suites. See <see cref="WhenAttribute{T}"/>
///         documentation for details.
///     </para>
///     <para>
///         Consider <see cref="CornerCaseAttribute{T}"/> if you want to
///         preserve the existing run, but still need an additional run with
///         customized testing context. See <see cref="CornerCaseAttribute{T}"/>
///         documentation for details.
///     </para>
/// </remarks>
public abstract class TestSuite<TContract>
where TContract : class
{
    /// <inheritdoc cref="ITestSuite{T}.It"/>
    required public TContract It { get; init; }
}

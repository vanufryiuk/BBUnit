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

using System;

namespace BBUnit;

/// <summary>
///     Initiates an additional test(s) run with the given precondition applied.
/// </summary>
/// <remarks>
///     <para>
///         The <see cref="EvenIfAttribute{TPrecondition}" /> attribute is
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
///     <see cref="ITestPrecondition"/> to use for the additional test(s) run.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
public class EvenIfAttribute<TPrecondition> : Attribute
where TPrecondition : ITestPrecondition
{
}

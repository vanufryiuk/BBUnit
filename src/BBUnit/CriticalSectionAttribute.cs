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
///     This attribute marks a testing context, a test suite, a test
///     precondition, or a test method as a critical section.
/// </summary>
/// <param name="sharedResource">
///     Name of the shared resource of this critical section.
/// </param>
/// <remarks>
///     <para>
///         A critical section is a piece of code that accesses a shared
///         resource and must be executed by only one thread at a time.
///     </para>
///     <para>
///         <paramref name="sharedResource"/> here is a unique shared resource
///         identifier. BBUnit never runs two or more critical sections with the
///         same <paramref name="sharedResource"/> in parallel even though
///         parallel execution is the default behavior of BBUnit. You are free
///         to use any <paramref name="sharedResource"/> value you want,
///         including a human readable one. You need just to keep it unique for
///         each shared resource you have.
///     </para>
///     <para>
///         Applied to <see cref="ITestingContext{T}"/>, this attribute denies
///         parallel execution for tests that use this testing context, as well
///         as parallel setup of them. Any other critical section with the same
///         <paramref name="sharedResource"/> will never run in parallel with
///         this one as well.
///     </para>
///     <para>
///         Applied to <see cref="ITestSuite{T}"/>, this attribute denies
///         parallel execution for it's tests. Parallel setup of them is still
///         allowed. Any other critical section with the same
///         <paramref name="sharedResource"/> will never run in parallel with
///         this one as well.
///     </para>
///     <para>
///         Applied to <see cref="ITestPrecondition"/>, this attribute denies
///         parallel execution for tests that use this precondition, as well as
///         parallel setup of these tests. Any other critical section with the
///         same <paramref name="sharedResource"/> will never run in parallel
///         with this one as well.
///     </para>
///     <para>
///         Applied to a specific test method, this attribute denies execution of
///         this test in parallel with any other critical section with the same
///         <paramref name="sharedResource"/>. Parallel setup of this test is
///         still allowed.
///     </para>
///     <para>
///         If you use more than one <see cref="CriticalSectionAttribute"/> on
///         the same target, it is treated as more than one shared resource used
///         by the target, and the logic above applies o each of them.
///     </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class CriticalSectionAttribute(string sharedResource) : Attribute
{
    /// <summary>
    /// Gets the name of the shared resource of this critical section.
    /// </summary>
    public string SharedResource { get; } = sharedResource;
}

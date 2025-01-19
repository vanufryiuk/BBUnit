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

using System.Threading.Tasks;

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
    /// <summary>
    /// Sets up
    /// </summary>
    /// <param name="initialSetup"></param>
    /// <returns></returns>
    ValueTask<ITargetSetup> SetupTargetAsync(ITargetSetup initialSetup);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="initialSetup"></param>
    /// <returns></returns>
    ValueTask<IDataSetup> SetupDataAsync(IDataSetup initialSetup);
}

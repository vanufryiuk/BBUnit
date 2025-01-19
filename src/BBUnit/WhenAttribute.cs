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
    ///     Gets or sets the order in which to apply the
    ///     <typeparamref name="TPrecondition"/> against the other
    ///     <see cref="WhenAttribute{T}"/> preconditions.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If you use more than one <see cref="WhenAttribute{T}"/>, you may
    ///         need to apply them to your testing context in a specific order.
    ///         This is the intention of this property.
    ///     </para>
    ///     <para>
    ///         Default order is alphabetical (just to keep your test runs
    ///         consistent by default).
    ///     </para>
    ///     <para>
    ///         If you set the same order for more than one
    ///         <see cref="WhenAttribute{T}"/>, these ones are ordered
    ///         alphabetically.
    ///     </para>
    ///     <para>
    ///         Any <see cref="WhenAttribute{T}"/> with no <see cref="Order"/>
    ///         set are applied at the end.
    ///     </para>
    ///     <para>
    ///         You should consider that <see cref="WhenAttribute{T}"/>
    ///         preconditions are always applied before
    ///         <see cref="CornerCaseAttribute{T}"/> ones.
    ///     </para>
    /// </remarks>
    /// <value>
    ///     Order in which to apply the <typeparamref name="TPrecondition"/>
    ///     against the other <see cref="WhenAttribute{T}"/> preconditions.
    /// </value>
    public uint? Order { get; set; }
}

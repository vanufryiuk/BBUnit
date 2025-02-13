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
///     This class is not intended to be used directly. Use generic
///     <see cref="SkipForAttribute{T}"/> instead.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SkipForAttribute : Attribute
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SkipForAttribute"/>
    ///     class.
    /// </summary>
    /// <param name="targets">
    ///     Definitions of the test abstractions to be skipped in combination
    ///     with the attribute target.
    /// </param>
    internal SkipForAttribute(params Type[] targets) => Targets = targets;

    /// <summary>
    ///     Gets an array of definitions of the test abstractions to be skipped
    ///     in combination with the attribute target.
    /// </summary>
    public Type[] Targets { get; }
}

public class SkipForAttribute<TTarget> : SkipForAttribute
{
    public SkipForAttribute()
    : base(typeof(TTarget))
    {
    }
}

public class SkipForAttribute<TTarget1, TTarget2> : SkipForAttribute
{
    public SkipForAttribute()
    : base(typeof(TTarget1), typeof(TTarget2))
    {
    }
}

public class SkipForAttribute<TTarget1, TTarget2, TTarget3> : SkipForAttribute
{
    public SkipForAttribute()
    : base(typeof(TTarget1), typeof(TTarget2), typeof(TTarget3))
    {
    }
}

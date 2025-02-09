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

// ATTENTION:
// This class is a nothing-to-add one (completely finished).
// You may want to update documentation but code.

/// <summary>
///     An attribute for skipping test case execution.
/// </summary>
/// <remarks>
///     <para>
///         Any test abstraction (test scenario, test suite, test precondition,
///         test fixture) marked with <see cref="SkipAttribute"/> will not be
///         used for running your test cases without a direct intention (direct
///         run of an ignored test case).
///     </para>
///     <para>
///         Skipped test cases are still discoverable (visible in the test
///         explorer and present in the test run statistics), unlike ones
///         disabled with <see cref="NotForAttribute"/>.
///     </para>
///     <para>
///         See <see href="https://github.com/vanufryiuk/BBUnit/blob/main/docs/UserGuide/SkippingTestCases.md#SkipAttribute"/>
///         for more details and examples.
///     </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SkipAttribute : Attribute;

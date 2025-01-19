// =============================================================================
// Copyright 2025 BBUnit contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http: //www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =============================================================================

namespace BBUnit;

/// <summary>
///     Interface for a test collection.
/// </summary>
/// <typeparam name="TContract">
///     Contract (class or interface) implemented the test target.
/// </typeparam>
/// <remarks>
///     <para>
///         Any <see cref="ITestSuite{TContract}"/> implementation is treated as
///         a test collection. <typeparamref name="TContract"/> here is a
///         contract (class or interface) implemented by the test target.
///     </para>
///     <para>
///         Use <see cref="It" /> property to access the test target instance.
///     </para>
///     <para>
///         Consider <see cref="TestSuite{TContract}"/> class instead if you
///         don't (and you probably don't) need test suite inheritance.
///     </para>
///     <para>
///         By default, BBUnit executes a test suite with no-op
///         <see cref="ITestingContext{TTestTarget}"/>. Create your own
///         <see cref="ITestingContext{TTestTarget}"/> to customize test data or
///         test target setup. See <see cref="ITestingContext{TTestTarget}"/>
///         documentation for details.
///     </para>
///     <para>
///         If you have more than one <see cref="ITestingContext{TTestTarget}"/>
///         with TTestTarget appropriate for your test suite, the test suite
///         will be run once for each of these
///         <see cref="ITestingContext{TTestTarget}"/> unless you disable some
///         with <see cref="NotForAttribute{T}"/>. Not to confuse with
///         <see cref="SkipForAttribute{T}"/> and
///         <see cref="SkipAttribute{T}"/>.
///     </para>
///     <para>
///         An "appropriate" TTestTarget for a test suite is any type which
///         implements or inherits the <typeparamref name="TContract"/> of the
///         test suite. So you'd probably want to use interfaces and
///         classes as contracts and test targets respectively.
///     </para>
///     <para>
///         It is also possible to have a generic
///         <see cref="ITestSuite{TContract}"/> implementation. In this case,
///         BBUnit tries to construct it for each appropriate
///         <see cref="ITestingContext{TTestTarget}"/> according to the type
///         parameter constraints. As well as for TTestingTarget matching rules,
///         you are free to disable specific combinations with
///         <see cref="NotForAttribute{T}"/>.
///     </para>
/// </remarks>
public interface ITestSuite<TContract>
where TContract : class
{
    /// <summary>
    ///     Gets the test target instance.
    /// </summary>
    /// <remarks>
    ///     BBUnit runtime is responsible for setting this property, so you may
    ///     want to mark it as <c>required</c> to avoid the compiler warning.
    /// </remarks>
    /// <value>
    ///     Test target instance.
    /// </value>
    public TContract It { get; init; }
}

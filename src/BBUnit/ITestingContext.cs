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
    ValueTask<ITargetSetup> SetupTargetAsync(ITargetSetup initialSetup);

    ValueTask<IDataSetup> SetupDataAsync(IDataSetup initialSetup);
}

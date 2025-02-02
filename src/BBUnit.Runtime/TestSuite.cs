using System;
using System.Collections.Generic;

namespace BBUnit.Runtime;

public class TestSuite
{
    public IEnumerable<TestFixture> AppropriateFixtures { get; }
}

using System;

namespace BBUnit;

public interface ITestContextConfig
{
    ITestContextConfig For(Type type, Func<ITestContextConfig, ITestContextConfig> configure);

    ITestContextConfig With(Type type, Func<ITestFixture, object> construct);
}

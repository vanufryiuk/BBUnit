using System;
using System.Threading.Tasks;

namespace BBUnit.Internal;

public interface IConfigureTestContext
{
    ValueTask<ITestContextConfig> ConfigureTestContextAsync(ITestContextConfig currentConfig)
        => ValueTask.FromResult(currentConfig);
}

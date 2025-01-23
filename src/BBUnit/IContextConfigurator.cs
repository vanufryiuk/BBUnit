using System;
using System.Threading.Tasks;

namespace BBUnit;

public interface IContextConfigurator
{
    ValueTask<IContextConfiguration> ConfigureContextAsync(IContextConfiguration currentConfig)
        => ValueTask.FromResult(currentConfig);
}

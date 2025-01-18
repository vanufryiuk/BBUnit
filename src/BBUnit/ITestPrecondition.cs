using System;

namespace BBUnit;

public interface ITestPrecondition
{
    ValueTask<ITargetSetup> SetupTargetAsync(ITargetSetup currentSetup);

    ValueTask<IDataSetup> SetupDataAsync(IDataSetup currentSetup);
}

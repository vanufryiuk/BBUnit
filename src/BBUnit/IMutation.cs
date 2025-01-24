using System.Threading.Tasks;

namespace BBUnit;

public interface IMutation<T> : Internal.IMutation
{
    public ValueTask<T> MutateAsync(T current)
        => ValueTask.FromResult(current);
}

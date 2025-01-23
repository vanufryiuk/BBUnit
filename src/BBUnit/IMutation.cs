using System.Threading.Tasks;

namespace BBUnit;

public interface IMutation<T>
{
    public ValueTask<T> MutateAsync(T current)
        => ValueTask.FromResult(current);
}

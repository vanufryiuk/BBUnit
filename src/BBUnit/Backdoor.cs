namespace BBUnit;

public static class Backdoor<TBackdoor>
{
    public static TBackdoor For(object target)
        => (TBackdoor)Internal.Backdoor.Get(typeof(TBackdoor), target)!;
}

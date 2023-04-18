namespace Common.Providers
{
    public abstract class AProvider<T> : IProvider<T>
    {
        public abstract T Get();
    }
}

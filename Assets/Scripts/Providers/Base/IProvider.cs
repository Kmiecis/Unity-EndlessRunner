namespace Common.Providers
{
    public interface IProvider<T>
    {
        T Get();
    }
}

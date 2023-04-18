namespace Common.Providers
{
    public class IteratingProviderBehaviour<T> : AArrayProviderBehaviour<IteratingProvider<T>, T>
    {
        protected override IteratingProvider<T> Construct()
        {
            return new IteratingProvider<T>(_values);
        }
    }
}

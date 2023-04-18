namespace Common.Providers
{
    public class ManualProviderBehaviour<T> : AArrayProviderBehaviour<ManualProvider<T>, T>
    {
        public void Set(int index)
        {
            Provider.Index = index;
        }

        protected override ManualProvider<T> Construct()
        {
            return new ManualProvider<T>(_values);
        }
    }
}

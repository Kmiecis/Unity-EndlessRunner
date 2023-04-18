namespace Common.Providers
{
    public class ManualProvider<T> : AArrayProvider<T>
    {
        public ManualProvider(T[] values) :
            base(values)
        {
        }
        
        public override T Get()
        {
            return Current;
        }
    }
}

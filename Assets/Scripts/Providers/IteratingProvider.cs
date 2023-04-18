namespace Common.Providers
{
    public class IteratingProvider<T> : AArrayProvider<T>
    {
        public IteratingProvider(T[] values) :
            base(values)
        {
            _index = -1;
        }
        
        public override T Get()
        {
            return Next;
        }
    }
}

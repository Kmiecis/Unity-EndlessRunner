namespace Common.Providers
{
    public abstract class AArrayProvider<T> : AProvider<T>
    {
        protected readonly T[] _values;
        protected int _index;

        public AArrayProvider(T[] values)
        {
            _values = values;
        }

        public T[] Values
        {
            get => _values;
        }

        public int Index
        {
            get => _index;
            set => _index = value;
        }

        protected T Current
        {
            get => _values[_index];
        }

        protected T Next
        {
            get => _values[(_index = (_index + 1) % _values.Length)];
        }

        protected T Prev
        {
            get => _values[(_index = (_index - 1 + _values.Length) % _values.Length)];
        }
    }
}

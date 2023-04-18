namespace Common.Providers
{
    public class CountedProvider<T> : AArrayProvider<T>
    {
        protected readonly int _repeats;
        protected int _remaining;

        public CountedProvider(T[] values, int repeats) :
            base(values)
        {
            _repeats = repeats;

            Remaining = repeats;
        }

        public int Remaining
        {
            get => _remaining;
            set => _remaining = value;
        }

        public override T Get()
        {
            if (--Remaining > 0)
            {
                return Current;
            }

            Remaining = _repeats;
            return Next;
        }
    }
}

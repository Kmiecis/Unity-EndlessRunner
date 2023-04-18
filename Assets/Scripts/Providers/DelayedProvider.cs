namespace Common.Providers
{
    public class DelayedProvider<T> : AArrayProvider<T>
    {
        protected readonly float _interval;
        protected readonly bool _unscaled;
        protected float _timeleft;

        public DelayedProvider(T[] values, float interval, bool unscaled = false) :
            base(values)
        {
            _interval = interval;
            _unscaled = unscaled;

            Remaining = interval;
        }

        private float Nowstamp
        {
            get => UTime.GetTime(_unscaled);
        }

        public float Remaining
        {
            get => _timeleft - Nowstamp;
            set => _timeleft = Nowstamp + value;
        }
        
        public override T Get()
        {
            if (Remaining > 0.0f)
            {
                return Current;
            }

            Remaining = _interval;
            return Next;
        }
    }
}

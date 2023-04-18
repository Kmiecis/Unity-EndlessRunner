using System;

namespace Common.Providers
{
    public class RandomProvider<T> : AArrayProvider<T>
    {
        protected readonly Random _random;

        public RandomProvider(T[] values, int seed = 0) :
            base(values)
        {
            _random = new Random(seed);
        }

        protected T Random
        {
            get => _values[(_index = _random.Next(_values.Length))];
        }

        public override T Get()
        {
            return Random;
        }
    }
}

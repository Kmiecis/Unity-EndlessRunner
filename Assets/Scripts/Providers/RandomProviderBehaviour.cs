using UnityEngine;

namespace Common.Providers
{
    public class RandomProviderBehaviour<T> : AArrayProviderBehaviour<RandomProvider<T>, T>
    {
        [SerializeField]
        protected int _seed;

        protected override RandomProvider<T> Construct()
        {
            return new RandomProvider<T>(_values, _seed);
        }
    }
}

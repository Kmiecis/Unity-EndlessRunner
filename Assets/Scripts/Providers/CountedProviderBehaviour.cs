using UnityEngine;

namespace Common.Providers
{
    public class CountedProviderBehaviour<T> : AArrayProviderBehaviour<CountedProvider<T>, T>
    {
        [SerializeField]
        protected int _repeats;

        protected override CountedProvider<T> Construct()
        {
            return new CountedProvider<T>(_values, _repeats);
        }
    }
}

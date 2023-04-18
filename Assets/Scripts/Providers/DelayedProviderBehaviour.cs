using UnityEngine;

namespace Common.Providers
{
    public class DelayedProviderBehaviour<T> : AArrayProviderBehaviour<DelayedProvider<T>, T>
    {
        [SerializeField]
        protected float _interval;
        [SerializeField]
        protected bool _unscaled;

        protected override DelayedProvider<T> Construct()
        {
            return new DelayedProvider<T>(_values, _interval, _unscaled);
        }
    }
}

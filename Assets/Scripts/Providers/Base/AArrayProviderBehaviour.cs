using UnityEngine;

namespace Common.Providers
{
    public abstract class AArrayProviderBehaviour<TProvider, TValue> : AProviderBehaviour<TProvider, TValue>
        where TProvider : AArrayProvider<TValue>
    {
        [SerializeField]
        protected TValue[] _values;
    }
}

using UnityEngine;

namespace Common.Providers
{
    public abstract class AProviderBehaviour<TProvider, TValue> : MonoBehaviour, IProvider<TValue>
        where TProvider : IProvider<TValue>
    {
        private TProvider _provider;

        protected TProvider Provider
        {
            get
            {
                if (_provider == null)
                    _provider = Construct();
                return _provider;
            }
        }

        protected abstract TProvider Construct();

        public TValue Get()
        {
            return Provider.Get();
        }
    }
}

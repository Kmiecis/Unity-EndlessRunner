using Common;
using UnityEngine;

namespace Game
{
    public class IteratingPoolers : APoolerProvider
    {
        public Pooler[] poolers;
        [SerializeField] [ReadOnlyField] protected int m_CurrentIndex;

        public override Pooler GetPooler()
        {
            return poolers[GetAndIncrCurrentIndex()];
        }

        protected int GetAndIncrCurrentIndex()
        {
            var result = m_CurrentIndex;
            m_CurrentIndex = Mathx.NextIndex(m_CurrentIndex, poolers.Length);
            return result;
        }
    }
}
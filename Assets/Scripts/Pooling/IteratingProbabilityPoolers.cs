using Common;
using UnityEngine;

namespace Game
{
    public class IteratingProbabilityPoolers : APoolerProvider
    {
        public ProbabilityPoolers[] poolers;
        [SerializeField] [ReadOnlyField] protected int m_CurrentIndex;

        protected Pooler GetPooler(int index)
        {
            return poolers[index].GetPooler();
        }

        protected int GetAndIncrCurrentIndex()
        {
            var result = m_CurrentIndex;
            m_CurrentIndex = Mathx.NextIndex(m_CurrentIndex, poolers.Length);
            return result;
        }

        public override Pooler GetPooler()
        {
            return GetPooler(GetAndIncrCurrentIndex());
        }
    }
}
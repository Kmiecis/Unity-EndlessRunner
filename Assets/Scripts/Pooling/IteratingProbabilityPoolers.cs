using Common;
using UnityEngine;

namespace Game
{
    public class IteratingProbabilityPoolers : APoolerProvider
    {
        public ProbabilityPoolers[] poolers;
        [ReadOnlyField] [SerializeField] protected int m_CurrentIndex;

        protected Pooler GetPooler(int index)
        {
            return poolers[index].GetPooler();
        }

        protected int GetAndIncrCurrentIndex()
        {
            var result = m_CurrentIndex;
            m_CurrentIndex = (m_CurrentIndex + 1) % poolers.Length;
            return result;
        }

        public override Pooler GetPooler()
        {
            return GetPooler(GetAndIncrCurrentIndex());
        }
    }
}
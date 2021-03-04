using Common;
using UnityEngine;

namespace Game
{
    public class CountedProbabilityPooler : IteratingProbabilityPoolers
    {
        public int repeats;
        [ReadOnlyField] [SerializeField] protected int m_Remaining;

        public override Pooler GetPooler()
        {
            if (m_Remaining-- <= 0)
            {
                m_Remaining = repeats;
                return GetPooler(GetAndIncrCurrentIndex());
            }
            return GetPooler(m_CurrentIndex);
        }

        private void Start()
        {
            m_Remaining = repeats;
        }
    }
}
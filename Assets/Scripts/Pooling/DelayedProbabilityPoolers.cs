using Common;
using UnityEngine;

namespace Game
{
    public class DelayedProbabilityPoolers : IteratingProbabilityPoolers
    {
        public float interval;
        [ReadOnlyField] [SerializeField] protected float m_Timeleft;

        public override Pooler GetPooler()
        {
            if (m_Timeleft <= 0.0f)
            {
                m_Timeleft += interval;
                return GetPooler(GetAndIncrCurrentIndex());
            }
            return GetPooler(m_CurrentIndex);
        }

        private void Start()
        {
            m_Timeleft = interval;
        }

        private void Update()
        {
            m_Timeleft -= Time.deltaTime;
        }
    }
}
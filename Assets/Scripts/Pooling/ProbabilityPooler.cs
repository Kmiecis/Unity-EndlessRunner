using UnityEngine;

namespace Game
{
    public class ProbabilityPooler : Pooler, IProbability
    {
        [SerializeField] protected int m_Probability;

        public int Probability => m_Probability;
    }
}
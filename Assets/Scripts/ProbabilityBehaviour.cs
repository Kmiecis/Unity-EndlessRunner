using UnityEngine;

namespace Game
{
    public class ProbabilityBehaviour : MonoBehaviour, IProbability
    {
        [SerializeField] protected int m_Probability;

        public int Probability => m_Probability;
    }
}
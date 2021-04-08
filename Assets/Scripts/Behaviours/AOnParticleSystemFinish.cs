using UnityEngine;

namespace Game
{
    public abstract class AOnParticleSystemFinish : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem m_ParticleSystem;

        private bool m_WasPlaying = false;

        private void Update()
        {
            if (!m_WasPlaying && m_ParticleSystem.isPlaying)
            {
                m_WasPlaying = true;
            }

            if (m_WasPlaying && !m_ParticleSystem.isPlaying)
            {
                m_WasPlaying = false;

                OnFinish();
            }
        }

        protected abstract void OnFinish();
    }
}
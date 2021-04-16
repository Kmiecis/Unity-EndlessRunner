using UnityEngine;

namespace Game
{
    public abstract class AOnAudioSourceFinish : MonoBehaviour
    {
        [SerializeField] protected AudioSource m_AudioSource;

        private bool m_WasPlaying = false;

        private void Update()
        {
            if (!m_WasPlaying && m_AudioSource.isPlaying)
            {
                m_WasPlaying = true;
            }

            if (m_WasPlaying && !m_AudioSource.isPlaying)
            {
                m_WasPlaying = false;

                OnFinish();
            }
        }

        protected abstract void OnFinish();
    }
}
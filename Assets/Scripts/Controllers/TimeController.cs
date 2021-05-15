using Common;
using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class TimeController : MonoBehaviour
    {
        private class TimeOverride
        {
            public float targetTimeScale;
            public float previousTimeScale;
        }

        private class TimeRequest
        {
            public float targetTimeScale;
            public float duration;

            public float initialTimeScale;
            public float initialDuration;
        }

        [SerializeField] [ReadOnlyField] protected float m_CurrentTimeScale = 1.0f;

        private float m_InitialTimeScale;
        private float m_InitialFixedDeltaTime;
        private float m_InitialMaximumDeltaTime;
        private float m_InitialMaximumParticleDeltaTime;

        private Queue<TimeRequest> m_Requests = new Queue<TimeRequest>();
        private TimeRequest m_Request = null;
        private TimeOverride m_Override = null;

        private void ApplyTimeScale(float value)
        {
            Time.timeScale = m_InitialTimeScale * value;
            Time.fixedDeltaTime = m_InitialFixedDeltaTime * value;
            Time.maximumDeltaTime = m_InitialMaximumDeltaTime * value;
            Time.maximumParticleDeltaTime = m_InitialMaximumParticleDeltaTime * value;
        }

        private void AddRequest(float timeScale, float transition)
        {
            var request = new TimeRequest
            {
                targetTimeScale = timeScale,
                duration = transition
            };
            m_Requests.Enqueue(request);
        }

        public void AddRequest(float timeScale, float fadeInDuration, float holdDuration, float fadeOutDuration)
        {
            AddRequest(timeScale, fadeInDuration);
            AddRequest(timeScale, holdDuration);
            AddRequest(Time.timeScale, fadeOutDuration);
        }

        public void StopTime()
        {
            ResumeTime();

            m_Override = new TimeOverride { targetTimeScale = 0.0f, previousTimeScale = Time.timeScale };

            ApplyTimeScale(m_Override.targetTimeScale);
        }

        public void ResumeTime()
        {
            if (m_Override != null)
            {
                ApplyTimeScale(m_Override.previousTimeScale);

                m_Override = null;
            }
        }
        
        private void UpdateRequests()
        {
            if (m_Requests.Count > 0 && m_Request == null)
            {
                m_Request = m_Requests.Dequeue();
                m_Request.initialTimeScale = Time.timeScale;
                m_Request.initialDuration = m_Request.duration;
            }
        }

        private void UpdateRequest()
        {
            if (m_Override == null && m_Request != null)
            {
                m_Request.duration -= Time.unscaledDeltaTime;

                var t = 1.0f - Mathf.Max(m_Request.duration / m_Request.initialDuration, 0.0f);
                var newTimeScale = Mathf.Lerp(m_Request.initialTimeScale, m_Request.targetTimeScale, t);

                ApplyTimeScale(newTimeScale);

                if (m_Request.duration <= 0.0f)
                {
                    m_Request = null;
                }
            }
        }

        private void Awake()
        {
            m_InitialTimeScale = Time.timeScale;
            m_InitialFixedDeltaTime = Time.fixedDeltaTime;
            m_InitialMaximumDeltaTime = Time.maximumDeltaTime;
            m_InitialMaximumParticleDeltaTime = Time.maximumParticleDeltaTime;
        }
        
        private void Update()
        {
            UpdateRequests();
            UpdateRequest();

            m_CurrentTimeScale = Time.timeScale;
        }

        private void OnDestroy()
        {
            Time.timeScale = m_InitialTimeScale;
            Time.fixedDeltaTime = m_InitialFixedDeltaTime;
            Time.maximumDeltaTime = m_InitialMaximumDeltaTime;
            Time.maximumParticleDeltaTime = m_InitialMaximumParticleDeltaTime;
        }
    }
}
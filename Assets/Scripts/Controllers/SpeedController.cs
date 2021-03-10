using Common;
using System;
using UnityEngine;

namespace Game
{
    public class SpeedController : MonoBehaviour
    {
        public event Action<float> OnSpeedChanged;

        [SerializeField] protected float m_StartSpeed = 1.0f;
        [SerializeField] protected float m_TargetSpeed = 3.0f;
        [SerializeField] protected float m_Acceleration = 0.01f;
        [SerializeField] protected float m_WindUpDuration = 2.0f;
        [SerializeField] protected float m_WindDownDuration = 2.0f;
        [ReadOnlyField] [SerializeField] protected float m_CurrentSpeed;

        protected bool m_IsHolded = false;

        public bool Hold
        {
            get { return m_IsHolded; }
            set { m_IsHolded = value; }
        }

        public float CurrentSpeed
        {
            get { return m_CurrentSpeed; }
            set { m_CurrentSpeed = value; OnSpeedChanged?.Invoke(value); }
        }
        
        public void Run()
        {
            var current = 0.0f;
            var target = m_StartSpeed;

            void WindUp(float t)
            {
                CurrentSpeed = Mathf.Lerp(current, target, t);
            }

            StartCoroutine(CoroutineUtility.InvokeOverTimeNormalized(WindUp, m_WindUpDuration));
        }
        
        public void Stop()
        {
            var current = m_CurrentSpeed;
            var target = 0.0f;

            void WindDown(float t)
            {
                CurrentSpeed = Mathf.Lerp(current, target, t);
            }

            StartCoroutine(CoroutineUtility.InvokeOverTimeNormalized(WindDown, m_WindDownDuration));
        }

        private bool CanUpdateSpeed()
        {
            return !m_IsHolded && m_StartSpeed <= m_CurrentSpeed && m_CurrentSpeed <= m_TargetSpeed;
        }

        private void UpdateSpeed()
        {
            CurrentSpeed = Mathf.Min(m_CurrentSpeed + m_Acceleration * Time.deltaTime, m_TargetSpeed);
        }

        private void Update()
        {
            if (CanUpdateSpeed())
            {
                UpdateSpeed();
            }
        }

        private void OnDestroy()
        {
            OnSpeedChanged = null;
        }
    }
}
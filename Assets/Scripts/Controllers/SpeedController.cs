using Common;
using Common.Coroutines;
using Common.Injection;
using System;
using UnityEngine;

namespace Game
{
    [DI_Install]
    public class SpeedController : MonoBehaviour
    {
        public event Action<float> OnSpeedChanged;

        public bool runOnStart = false;
        public float startSpeed = 1.0f;
        public float targetSpeed = 3.0f;
        public float acceleration = 0.01f;
        public float windUpDuration = 2.0f;
        public float windDownDuration = 2.0f;

        [SerializeField, ReadOnly] protected float m_CurrentSpeed;

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
            var target = startSpeed;

            void WindUp(float t)
            {
                CurrentSpeed = Mathf.Lerp(current, target, t);
            }

            UCoroutine.YieldTimeNormalized(windUpDuration)
                .Into(WindUp)
                .Start(this);
        }
        
        public void Stop()
        {
            var current = m_CurrentSpeed;
            var target = 0.0f;

            void WindDown(float t)
            {
                CurrentSpeed = Mathf.Lerp(current, target, t);
            }

            UCoroutine.YieldTimeNormalized(windDownDuration)
                .Into(WindDown)
                .Start(this);
        }

        private bool CanUpdateSpeed()
        {
            return !m_IsHolded && startSpeed <= m_CurrentSpeed && m_CurrentSpeed <= targetSpeed;
        }

        private void UpdateSpeed()
        {
            CurrentSpeed = Mathf.Min(m_CurrentSpeed + acceleration * Time.deltaTime, targetSpeed);
        }

        private void Awake()
        {
            DI_Binder.Bind(this);
        }

        private void Start()
        {
            if (runOnStart)
            {
                Run();
            }
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

            DI_Binder.Unbind(this);
        }
    }
}
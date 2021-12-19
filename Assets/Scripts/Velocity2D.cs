using Common.Injection;
using UnityEngine;

namespace Game
{
    public class Velocity2D : DI_ADependantBehaviour
    {
        [DI_Inject]
        private SpeedController m_SpeedController;

        [SerializeField]
        protected Rigidbody2D m_Rigidbody;

        [Space(10)]
        public float speed = 1.0f;
        public Vector2 direction;

        private bool m_Started = false;

        private void SetVelocity(float multiplier)
        {
            m_Rigidbody.velocity = speed * direction * multiplier;
        }

        private void OnEnable()
        {
            if (m_Started)
                SetVelocity(m_SpeedController.CurrentSpeed);
        }
        
        private void Start()
        {
            m_SpeedController.OnSpeedChanged += SetVelocity;

            m_Started = true;
            SetVelocity(m_SpeedController.CurrentSpeed);
        }

        protected override void OnDestroy()
        {
            m_SpeedController.OnSpeedChanged -= SetVelocity;

            base.OnDestroy();
        }
    }
}
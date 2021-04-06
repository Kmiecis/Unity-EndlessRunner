using UnityEngine;

namespace Game
{
    public class Velocity2D : MonoBehaviour
    {
        private static SpeedController SpeedController => SpeedController.Instance;

        [SerializeField] protected Rigidbody2D m_Rigidbody;

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
                SetVelocity(SpeedController.CurrentSpeed);
        }

        private void Start()
        {
            SpeedController.OnSpeedChanged += SetVelocity;

            m_Started = true;
            SetVelocity(SpeedController.CurrentSpeed);
        }
    }
}
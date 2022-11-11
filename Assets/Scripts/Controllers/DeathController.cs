using Common.Injection;
using UnityEngine;

namespace Game
{
    [DI_Install]
    public class DeathController : MonoBehaviour
    {
        [DI_Inject]
        private CameraController m_CameraController;

        [DI_Inject]
        private GameOverController m_GameOverController;

        [DI_Inject]
        private Player m_Player;

        [SerializeField]
        protected Vector2 m_BoundsOffset;

        private Vector2 DeathBounds
        {
            get
            {
                return new Vector2(
                    m_CameraController.Min.x + m_BoundsOffset.x,
                    m_CameraController.Min.y + m_BoundsOffset.y
                );
            }
        }

        private void UpdatePlayer()
        {
            var playerPosition = m_Player.transform.position;
            var deathBounds = DeathBounds;
            var isPlayerDead = playerPosition.x < deathBounds.x || playerPosition.y < deathBounds.y;

            if (isPlayerDead)
            {
                m_Player.Kill();

                m_GameOverController.SetGameOver();
            }
        }

        private void Awake()
        {
            DI_Binder.Bind(this);
        }

        private void Update()
        {
            if (m_Player.IsAlive)
            {
                UpdatePlayer();
            }
        }

        private void OnDestroy()
        {
            DI_Binder.Unbind(this);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var deathBounds = DeathBounds;
            var prevColor = Gizmos.color;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(deathBounds.x, deathBounds.y, 0.0f), new Vector3(deathBounds.x, 9999.0f, 0.0f));
            Gizmos.DrawLine(new Vector3(deathBounds.x, deathBounds.y, 0.0f), new Vector3(9999.0f, deathBounds.y, 0.0f));

            Gizmos.color = prevColor;
        }
#endif
    }
}
using Common;
using UnityEngine;

namespace Game
{
    public class DeathController : DependantBehaviour
    {
        [DependencyInject]
        private CameraController m_CameraController;

        [DependencyInject]
        private GameOverController m_GameOverController;

        [DependencyInject]
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

        private void Update()
        {
            if (m_Player.IsAlive)
            {
                UpdatePlayer();
            }
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
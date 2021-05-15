using Common;

namespace Game
{
    public class GameOverController : DependantBehaviour
    {
        [DependencyInject("OnGameOverScreen")]
        private GameOverScreen m_GameOverScreen;

        [DependencyInject]
        private TimeController m_TimeController;

        protected bool m_IsGameOver;

        public bool IsGameOver => m_IsGameOver;

        private void OnGameOverScreen(GameOverScreen gameOverScreen)
        {
            gameOverScreen.SetActive(m_IsGameOver);
        }

        public void SetGameOver()
        {
            m_IsGameOver = true;
            m_GameOverScreen.SetActive(m_IsGameOver);
            m_TimeController.StopTime();
        }
    }
}
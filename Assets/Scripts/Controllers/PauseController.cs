using Common;

namespace Game
{
    public class PauseController : DependantBehaviour
    {
        [DependencyInject]
        private InputController m_InputController;

        [DependencyInject]
        private TimeController m_TimeController;

        [DependencyInject]
        private GameOverController m_GameOverController;

        [DependencyInject("OnPauseScreen")]
        private PauseScreen m_PauseScreen;

        protected bool m_IsPaused;

        public bool IsPaused => m_IsPaused;

        private void TogglePauseScreen()
        {
            if (m_GameOverController.IsGameOver)
                return;

            m_IsPaused = !m_IsPaused;
            m_PauseScreen.SetActive(m_IsPaused);
            
            if (m_IsPaused)
                m_TimeController.StopTime();
            else
                m_TimeController.ResumeTime();
        }

        private void OnPauseScreen(PauseScreen pauseScreen)
        {
            pauseScreen.SetActive(m_IsPaused);
        }

        private void Start()
        {
            m_InputController.OnPauseActionDown += TogglePauseScreen;
        }
    }
}
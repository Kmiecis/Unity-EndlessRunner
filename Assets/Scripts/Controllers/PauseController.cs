using Common.Injection;

namespace Game
{
    public class PauseController : DI_ADependantBehaviour
    {
        [DI_Inject]
        private InputController m_InputController;

        [DI_Inject]
        private TimeController m_TimeController;

        [DI_Inject]
        private GameOverController m_GameOverController;

        [DI_Inject]
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

        private void OnPauseScreenInject(PauseScreen pauseScreen)
        {
            pauseScreen.SetActive(m_IsPaused);
        }

        private void Start()
        {
            m_InputController.OnPauseActionDown += TogglePauseScreen;
        }
    }
}
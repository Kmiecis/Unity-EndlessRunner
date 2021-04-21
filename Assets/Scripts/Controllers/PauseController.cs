using UnityEngine;

namespace Game
{
    public class PauseController : SingletonBehaviour<PauseController>
    {
        private static UIController UIController => UIController.Instance;
        private static InputController InputController => InputController.Instance;
        private static TimeController TimeController => TimeController.Instance;

        public GameObject pauseScreenPrefab;

        private bool m_IsPaused;
        private GameObject m_PauseScreen;

        private void TogglePauseScreen()
        {
            m_IsPaused = !m_IsPaused;
            m_PauseScreen.SetActive(m_IsPaused);

            if (m_IsPaused)
                TimeController.SetOverride(0.0f);
            else
                TimeController.RemoveOverride();
        }

        private void Start()
        {
            m_PauseScreen = Instantiate(pauseScreenPrefab, UIController.Canvas.transform);
            m_PauseScreen.SetActive(m_IsPaused);

            InputController.OnPauseActionDown += TogglePauseScreen;
        }
    }
}
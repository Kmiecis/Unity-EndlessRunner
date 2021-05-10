using Common;
using UnityEngine;

namespace Game
{
    public class PauseController : MonoBehaviour
    {
        [Dependant]
        private UIController m_UIController;

        [Dependant]
        private InputController m_InputController;

        [Dependant]
        private TimeController m_TimeController;

        public GameObject pauseScreenPrefab;

        private bool m_IsPaused;
        private GameObject m_PauseScreen;

        private void TogglePauseScreen()
        {
            m_IsPaused = !m_IsPaused;
            m_PauseScreen.SetActive(m_IsPaused);

            if (m_IsPaused)
                m_TimeController.SetOverride(0.0f);
            else
                m_TimeController.RemoveOverride();
        }

        private void Awake()
        {
            Dependencies.Bind(this);
        }

        private void Start()
        {
            m_PauseScreen = Instantiate(pauseScreenPrefab, m_UIController.Canvas.transform);
            m_PauseScreen.SetActive(m_IsPaused);

            m_InputController.OnPauseActionDown += TogglePauseScreen;
        }
    }
}
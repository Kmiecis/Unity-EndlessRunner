using Common;
using UnityEngine;

namespace Game
{
    public class PauseController : DependantBehaviour
    {
        [DependencyInstall, SerializeField]
        protected PauseScreen m_PauseScreenPrefab;
        
        [DependencyInject]
        private InputController m_InputController;

        [DependencyInject]
        private TimeController m_TimeController;

        [DependencyInject("OnPauseScreen")]
        private PauseScreen m_PauseScreen;
        
        private void TogglePauseScreen()
        {
            var isPaused = !m_PauseScreen.IsPaused;
            m_PauseScreen.IsPaused = isPaused;
            
            if (isPaused)
                m_TimeController.SetOverride(0.0f);
            else
                m_TimeController.RemoveOverride();
        }

        private void OnPauseScreen(PauseScreen pauseScreen)
        {
            pauseScreen.IsPaused = false;
        }

        private void Start()
        {
            m_InputController.OnPauseActionDown += TogglePauseScreen;
        }
    }
}
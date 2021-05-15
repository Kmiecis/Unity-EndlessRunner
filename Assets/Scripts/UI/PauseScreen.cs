﻿using Common;

namespace Game
{
    public class PauseScreen : DependantBehaviour
    {
        [DependencyInject("OnUIController")]
        private UIController m_UIController;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
        
        private void OnUIController(UIController uiController)
        {
            transform.SetParent(uiController.Canvas.transform, false);
        }
    }
}
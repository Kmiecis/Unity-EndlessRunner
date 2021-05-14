using Common;
using UnityEngine;

namespace Game
{
    public class PauseScreen : DependantBehaviour
    {
        [DependencyInject("OnUIController")]
        private UIController m_UIController;

        [SerializeField, ReadOnlyField]
        protected bool m_IsPaused;

        public bool IsPaused
        {
            get { return m_IsPaused; }
            set
            {
                m_IsPaused = value;
                gameObject.SetActive(value);
            }
        }

        private void OnUIController(UIController uiController)
        {
            transform.SetParent(uiController.Canvas.transform, false);
        }
    }
}
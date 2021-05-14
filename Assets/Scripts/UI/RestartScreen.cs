using Common;
using UnityEngine;

namespace Game
{
    public class RestartScreen : DependantBehaviour
    {
        [DependencyInject("OnUIController")]
        private UIController m_UIController;

        [SerializeField, ReadOnlyField]
        protected bool m_IsRestarting;

        public bool IsRestarting
        {
            get { return m_IsRestarting; }
            set
            {
                m_IsRestarting = value;
                gameObject.SetActive(value);
            }
        }

        private void OnUIController(UIController uiController)
        {
            transform.SetParent(uiController.Canvas.transform, false);
        }
    }
}
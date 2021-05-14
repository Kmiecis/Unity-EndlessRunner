using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [DependencyInject]
        private InputController m_InputController;

        public void OnPointerDown(PointerEventData eventData)
        {
            m_InputController.SetMainButtonDown();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_InputController.SetMainButtonUp();
        }

        private void Awake()
        {
            Dependencies.Bind(this);
        }
    }
}
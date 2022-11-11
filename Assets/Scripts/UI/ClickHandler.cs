using Common.Injection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [DI_Inject]
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
            DI_Binder.Bind(this);
        }

        private void OnDestroy()
        {
            DI_Binder.Unbind(this);
        }
    }
}
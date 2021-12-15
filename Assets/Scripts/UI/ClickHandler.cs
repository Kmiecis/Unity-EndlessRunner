using Common.Injection;
using UnityEngine.EventSystems;

namespace Game
{
    public class ClickHandler : DI_ADependantBehaviour, IPointerDownHandler, IPointerUpHandler
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
    }
}
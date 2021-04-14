using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private static InputController InputController => InputController.Instance;

        public void OnPointerDown(PointerEventData eventData)
        {
            InputController.SetMainButtonDown();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputController.SetMainButtonUp();
        }
    }
}
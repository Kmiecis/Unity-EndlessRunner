using Common.Injection;
using UnityEngine;

namespace Game
{
    [DI_Install]
    public class PauseScreen : MonoBehaviour
    {
        [DI_Inject]
        private UIController m_UIController;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
        
        private void OnUIControllerInject(UIController uiController)
        {
            transform.SetParent(uiController.Canvas.transform, false);
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
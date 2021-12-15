using Common.Injection;

namespace Game
{
    public class PauseScreen : DI_ADependantBehaviour
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
    }
}
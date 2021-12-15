using Common.Injection;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameOverScreen : DI_ADependantBehaviour
    {
        [DI_Inject]
        private UIController m_UIController;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnUIControllerInject(UIController uiController)
        {
            transform.SetParent(uiController.Canvas.transform, false);
        }
    }
}
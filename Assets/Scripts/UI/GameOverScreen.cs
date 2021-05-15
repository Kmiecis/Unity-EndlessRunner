using Common;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameOverScreen : DependantBehaviour
    {
        [DependencyInject("OnUIController")]
        private UIController m_UIController;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnUIController(UIController uiController)
        {
            transform.SetParent(uiController.Canvas.transform, false);
        }
    }
}
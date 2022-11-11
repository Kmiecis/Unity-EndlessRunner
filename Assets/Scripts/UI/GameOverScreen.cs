using Common.Injection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    [DI_Install]
    public class GameOverScreen : MonoBehaviour
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

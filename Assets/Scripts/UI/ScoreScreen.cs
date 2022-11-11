using Common.Injection;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [DI_Install]
    public class ScoreScreen : MonoBehaviour
    {
        [DI_Inject]
        private UIController m_UIController;

        [DI_Inject]
        private ScoreController m_ScoreController;

        public Text scoreText;

        private void OnScoreChanged(int score)
        {
            scoreText.text = score.ToString("000 000 000");
        }

        private void OnScoreControllerInject(ScoreController scoreController)
        {
            scoreController.OnScoreChanged += OnScoreChanged;

            OnScoreChanged(0);
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
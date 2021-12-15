using Common.Injection;
using UnityEngine.UI;

namespace Game
{
    public class ScoreScreen : DI_ADependantBehaviour
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
    }
}
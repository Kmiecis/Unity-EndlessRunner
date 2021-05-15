using Common;
using UnityEngine.UI;

namespace Game
{
    public class ScoreScreen : DependantBehaviour
    {
        [DependencyInject("OnUIController")]
        private UIController m_UIController;

        [DependencyInject("OnScoreController")]
        private ScoreController m_ScoreController;

        public Text scoreText;

        private void OnScoreChanged(int score)
        {
            scoreText.text = score.ToString("000 000 000");
        }

        private void OnScoreController(ScoreController scoreController)
        {
            scoreController.OnScoreChanged += OnScoreChanged;

            OnScoreChanged(0);
        }

        private void OnUIController(UIController uiController)
        {
            transform.SetParent(uiController.Canvas.transform, false);
        }
    }
}
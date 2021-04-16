using UnityEngine;

namespace Game
{
    public class Score2D : Pick2D
    {
        private static ScoreController ScoreController => ScoreController.Instance;

        [Space(10)]
        public int score = 50;

        protected override void OnPlayerEnter(Player player)
        {
            base.OnPlayerEnter(player);

            ScoreController.TryIncreaseScore(score);
        }
    }
}
using Common;
using UnityEngine;

namespace Game
{
    public class Score2D : Pick2D
    {
        [DependencyInject]
        private ScoreController m_ScoreController;

        [Space(10)]
        public int score = 50;

        private void Awake()
        {
            Dependencies.Bind(this);
        }

        protected override void OnPlayerEnter(Player player)
        {
            base.OnPlayerEnter(player);

            m_ScoreController.TryIncreaseScore(score);
        }
    }
}
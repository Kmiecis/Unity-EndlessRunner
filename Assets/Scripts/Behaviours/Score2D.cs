using Common.Injection;
using UnityEngine;

namespace Game
{
    public class Score2D : Pick2D
    {
        [DI_Inject]
        private ScoreController m_ScoreController;

        [Space(10)]
        public int score = 50;
        
        protected override void OnPlayerEnter(Player player)
        {
            base.OnPlayerEnter(player);

            m_ScoreController.TryIncreaseScore(score);
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
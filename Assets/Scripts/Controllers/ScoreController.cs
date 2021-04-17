using Common;
using System;
using UnityEngine;

namespace Game
{
    public class ScoreController : SingletonBehaviour<ScoreController>
    {
        public event Action<int> OnScoreChanged;

        [SerializeField] protected float m_Acceleration = 4.0f;
        [SerializeField] [ReadOnlyField] protected int m_CurrentScore;

        protected float m_ScoreAccumulator;
        protected bool m_IsHolded;

        public bool Hold
        {
            get { return m_IsHolded; }
            set { m_IsHolded = value; }
        }

        public int CurrentScore
        {
            get { return m_CurrentScore; }
            set { m_CurrentScore = value; OnScoreChanged?.Invoke(value); }
        }

        private bool CanUpdateScore()
        {
            return !m_IsHolded;
        }

        public void TryIncreaseScore(int delta)
        {
            if (CanUpdateScore())
            {
                CurrentScore = m_CurrentScore + delta;
            }
        }

        private void UpdateScore()
        {
            m_ScoreAccumulator += m_Acceleration * Time.deltaTime;
            while (m_ScoreAccumulator >= 1.0f)
            {
                CurrentScore = m_CurrentScore + 1;

                m_ScoreAccumulator -= 1.0f;
            }
        }
        
        private void Update()
        {
            if (CanUpdateScore())
            {
                UpdateScore();
            }
        }

        private void OnDestroy()
        {
            OnScoreChanged = null;
        }
    }
}
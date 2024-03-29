﻿using Common.Injection;
using UnityEngine;

namespace Game
{
    [DI_Install]
    public class GameOverController : MonoBehaviour
    {
        [DI_Inject]
        private GameOverScreen m_GameOverScreen;

        [DI_Inject]
        private TimeController m_TimeController;

        protected bool m_IsGameOver;

        public bool IsGameOver => m_IsGameOver;

        private void OnGameOverScreenInject(GameOverScreen gameOverScreen)
        {
            gameOverScreen.SetActive(m_IsGameOver);
        }

        public void SetGameOver()
        {
            m_IsGameOver = true;
            m_GameOverScreen.SetActive(m_IsGameOver);
            m_TimeController.StopTime();
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
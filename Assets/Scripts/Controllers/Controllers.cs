﻿using Common;

namespace Game
{
    public class Controllers : DependantBehaviour
    {
        [DependencyInstall]
        public UIController uiControllerPrefab;

        [DependencyInstall]
        public CameraController cameraControllerPrefab;

        [DependencyInstall]
        public InputController inputControllerPrefab;

        [DependencyInstall]
        public TimeController timeControllerPrefab;

        [DependencyInstall]
        public ScoreController scoreControllerPrefab;

        [DependencyInstall]
        public SpeedController speedControllerPrefab;

        [DependencyInstall]
        public PauseController pauseControllerPrefab;

        [DependencyInstall]
        public GameOverController gameOverControllerPrefab;

        [DependencyInstall]
        public DeathController deathControllerPrefab;

        [DependencyInstall]
        public Player playerPrefab;
    }
}
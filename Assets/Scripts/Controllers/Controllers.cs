using Common;
using UnityEngine;

namespace Game
{
    public class Controllers : MonoBehaviour
    {
        [DependencyFromPrefab]
        public UIController uiControllerPrefab;

        [DependencyFromPrefab]
        public CameraController cameraControllerPrefab;

        [DependencyFromPrefab]
        public InputController inputControllerPrefab;

        [DependencyFromPrefab]
        public TimeController timeControllerPrefab;

        [DependencyFromPrefab]
        public ScoreController scoreControllerPrefab;

        [DependencyFromPrefab]
        public SpeedController speedControllerPrefab;

        [DependencyFromPrefab]
        public PauseController pauseControllerPrefab;

        [DependencyFromPrefab]
        public RestartController restartControllerPrefab;

        [DependencyFromPrefab]
        public PlayerController playerControllerPrefab;

        private void Awake()
        {
            Dependencies.Install(this);
        }
    }
}
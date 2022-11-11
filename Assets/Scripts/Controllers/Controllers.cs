using UnityEngine;

namespace Game
{
    public class Controllers : MonoBehaviour
    {
        public UIController uiControllerPrefab;
        public CameraController cameraControllerPrefab;
        public InputController inputControllerPrefab;
        public TimeController timeControllerPrefab;
        public ScoreController scoreControllerPrefab;
        public SpeedController speedControllerPrefab;
        public PauseController pauseControllerPrefab;
        public GameOverController gameOverControllerPrefab;
        public DeathController deathControllerPrefab;
        public Player playerPrefab;

        private void Awake()
        {
            uiControllerPrefab = Instantiate(uiControllerPrefab);
            cameraControllerPrefab = Instantiate(cameraControllerPrefab);
            inputControllerPrefab = Instantiate(inputControllerPrefab);
            timeControllerPrefab = Instantiate(timeControllerPrefab);
            scoreControllerPrefab = Instantiate(scoreControllerPrefab);
            speedControllerPrefab = Instantiate(speedControllerPrefab);
            pauseControllerPrefab = Instantiate(pauseControllerPrefab);
            gameOverControllerPrefab = Instantiate(gameOverControllerPrefab);
            deathControllerPrefab = Instantiate(deathControllerPrefab);
            playerPrefab = Instantiate(playerPrefab);
        }
    }
}
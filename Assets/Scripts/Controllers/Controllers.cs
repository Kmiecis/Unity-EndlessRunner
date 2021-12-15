using Common.Injection;

namespace Game
{
    public class Controllers : DI_ADependantBehaviour
    {
        [DI_Install]
        public UIController uiControllerPrefab;

        [DI_Install]
        public CameraController cameraControllerPrefab;

        [DI_Install]
        public InputController inputControllerPrefab;

        [DI_Install]
        public TimeController timeControllerPrefab;

        [DI_Install]
        public ScoreController scoreControllerPrefab;

        [DI_Install]
        public SpeedController speedControllerPrefab;

        [DI_Install]
        public PauseController pauseControllerPrefab;

        [DI_Install]
        public GameOverController gameOverControllerPrefab;

        [DI_Install]
        public DeathController deathControllerPrefab;

        [DI_Install]
        public Player playerPrefab;
    }
}
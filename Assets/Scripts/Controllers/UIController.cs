using Common.Injection;
using UnityEngine;

namespace Game
{
    [DI_Install]
    public class UIController : MonoBehaviour
    {
        public PauseScreen pauseScreenPrefab;
        public GameOverScreen gameOverScreenPrefab;
        public ScoreScreen scoreScreenPrefab;

        [DI_Inject]
        private CameraController m_CameraController;

        [SerializeField]
        protected Canvas m_Canvas;

        [SerializeField]
        protected Camera m_Camera;

        public Canvas Canvas => m_Canvas;

        public Camera Camera => m_Camera;
        
        private void OnCameraControllerInject(CameraController cameraController)
        {
            var cameraData = cameraController.CameraData;
            var cameraStack = cameraData.cameraStack;
            cameraStack.Add(m_Camera);
        }

        private void Awake()
        {
            DI_Binder.Bind(this);

            pauseScreenPrefab = Instantiate(pauseScreenPrefab);
            gameOverScreenPrefab = Instantiate(gameOverScreenPrefab);
            scoreScreenPrefab = Instantiate(scoreScreenPrefab);
        }

        private void OnDestroy()
        {
            DI_Binder.Unbind(this);
        }
    }
}
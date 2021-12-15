using Common.Injection;
using UnityEngine;

namespace Game
{
    public class UIController : DI_ADependantBehaviour
    {
        [DI_Install]
        public PauseScreen pauseScreenPrefab;

        [DI_Install]
        public GameOverScreen gameOverScreenPrefab;

        [DI_Install]
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
    }
}
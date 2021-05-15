using Common;
using UnityEngine;

namespace Game
{
    public class UIController : DependantBehaviour
    {
        [DependencyInstall]
        public PauseScreen pauseScreenPrefab;

        [DependencyInstall]
        public GameOverScreen gameOverScreenPrefab;

        [DependencyInstall]
        public ScoreScreen scoreScreenPrefab;

        [DependencyInject("OnCameraController")]
        private CameraController m_CameraController;

        [SerializeField]
        protected Canvas m_Canvas;

        [SerializeField]
        protected Camera m_Camera;

        public Canvas Canvas => m_Canvas;

        public Camera Camera => m_Camera;
        
        private void OnCameraController(CameraController cameraController)
        {
            var cameraData = cameraController.CameraData;
            var cameraStack = cameraData.cameraStack;
            cameraStack.Add(m_Camera);
        }
    }
}
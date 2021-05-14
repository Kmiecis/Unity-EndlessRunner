using Common;
using UnityEngine;

namespace Game
{
    public class UIController : DependantBehaviour
    {
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
            if (cameraController == null)
                return;

            var cameraData = cameraController.CameraData;
            var cameraStack = cameraData.cameraStack;
            cameraStack.Add(m_Camera);
        }
    }
}
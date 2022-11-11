using Common;
using Common.Injection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game
{
    [DI_Install]
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        protected Camera m_Camera;

        [SerializeField]
        protected UniversalAdditionalCameraData m_CameraData;

        [SerializeField, ReadOnly]
        protected float m_Zoom;

        public Camera Camera => m_Camera;

        public UniversalAdditionalCameraData CameraData => m_CameraData;

        public float Width => m_Camera.aspect * Height;

        public float Height => m_Camera.orthographicSize * 2.0f;

        public Vector2 Size => new Vector2(Width, Height);

        public Vector2 Min => (Vector2)m_Camera.transform.position - Size * 0.5f;

        public Vector2 Max => (Vector2)m_Camera.transform.position + Size * 0.5f;

        public float Zoom
        {
            get { return m_Zoom; }
            set
            {
                var delta = value - m_Zoom;

                m_Camera.orthographicSize += delta;
                var newPosition = m_Camera.transform.position;
                newPosition.y += delta;
                m_Camera.transform.position = newPosition;

                m_Zoom = value;
            }
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
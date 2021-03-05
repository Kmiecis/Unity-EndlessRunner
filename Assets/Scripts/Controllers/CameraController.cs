using Common;
using UnityEngine;

namespace Game
{
    public class CameraController : SingletonBehaviour<CameraController>
    {
        public Camera mainCamera;

        [ReadOnlyField] [SerializeField] protected float m_Zoom;

        public float Zoom
        {
            get { return m_Zoom; }
            set
            {
                var delta = value - m_Zoom;

                mainCamera.orthographicSize += delta;
                var newPosition = mainCamera.transform.position;
                newPosition.y += delta;
                mainCamera.transform.position = newPosition;

                m_Zoom = value;
            }
        }

        public float Width => mainCamera.aspect * Height;
        public float Height => mainCamera.orthographicSize * 2.0f;
        public Vector2 Size => new Vector2(Width, Height);
        public Vector2 Min => (Vector2)mainCamera.transform.position - Size * 0.5f;
        public Vector2 Max => (Vector2)mainCamera.transform.position + Size * 0.5f;
    }
}
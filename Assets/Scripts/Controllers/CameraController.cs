using Common;
using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] protected Camera m_MainCamera;
        [ReadOnlyField] [SerializeField] protected float m_Zoom;

        public Camera MainCamera => m_MainCamera;

        public float Zoom
        {
            get { return m_Zoom; }
            set
            {
                var delta = value - m_Zoom;

                m_MainCamera.orthographicSize += delta;
                var newPosition = m_MainCamera.transform.position;
                newPosition.y += delta;
                m_MainCamera.transform.position = newPosition;

                m_Zoom = value;
            }
        }

        public float Width => m_MainCamera.aspect * Height;
        public float Height => m_MainCamera.orthographicSize * 2.0f;
        public Vector2 Size => new Vector2(Width, Height);
        public Vector2 Min => (Vector2)m_MainCamera.transform.position - Size * 0.5f;
        public Vector2 Max => (Vector2)m_MainCamera.transform.position + Size * 0.5f;
    }
}
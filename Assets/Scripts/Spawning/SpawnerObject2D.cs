using Common;
using UnityEngine;

namespace Game
{
    [ExecuteInEditMode]
    public class SpawnerObject2D : PoolingObject
    {
        [ReadOnlyField] [SerializeField] protected Range2 m_Range;

        public Vector2 Min => (Vector2)transform.position + m_Range.min;
        public Vector2 Max => (Vector2)transform.position + m_Range.max;
        public Vector2 Center => (Vector2)transform.position + m_Range.Center;
        public Vector2 Size => m_Range.Size;

        private void Read()
        {
            m_Range.min = Vector2.one * float.MaxValue;
            m_Range.max = Vector2.one * float.MinValue;

            if (TryGetComponent(out Collider2D collider))
            {
                IncludeCollider(collider);
            }

            var colliders = GetComponentsInChildren<Collider2D>();
            for (int i = 0; colliders != null && i < colliders.Length; i++)
            {
                IncludeCollider(colliders[i]);
            }
        }

        private void IncludeCollider(Collider2D collider)
        {
            var position = collider.transform.position;
            var bounds = collider.bounds;
            var min = bounds.min + position;
            var max = bounds.max + position;

            m_Range.Include(min, max);
        }

        private void Awake()
        {
            Read();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(Center, Size);
        }
#endif
    }
}
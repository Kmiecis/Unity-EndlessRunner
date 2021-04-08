using UnityEngine;

namespace Game
{
    public class TransformEnableRepositioner2D : AOnEnable
    {
        public Vector2 raycastOffset;
        public Vector2 positionOffset;

        protected override void OnEnable()
        {
            var downwardHit = Physics2D.Raycast((Vector2)transform.position + raycastOffset, Vector2.down, 999.0f);
            if (downwardHit)
            {
                var newPosition = downwardHit.point;

                newPosition.x += positionOffset.x;
                newPosition.y += positionOffset.y;

                transform.position = newPosition;
            }
        }
    }
}
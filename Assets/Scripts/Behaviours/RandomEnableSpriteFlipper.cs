using UnityEngine;

namespace Game
{
    public class RandomEnableSpriteFlipper : AOnEnable
    {
        [SerializeField] protected SpriteRenderer m_Target;

        public bool flipX;
        public bool flipY;

        protected override void OnEnable()
        {
            if (flipX)
                m_Target.flipX = Random.Range(0, 2) == 1;
            if (flipY)
                m_Target.flipY = Random.Range(0, 2) == 1;
        }
    }
}
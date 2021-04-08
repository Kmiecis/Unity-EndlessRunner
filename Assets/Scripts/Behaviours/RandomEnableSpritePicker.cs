using UnityEngine;

namespace Game
{
    public class RandomEnableSpritePicker : AOnEnable
    {
        [SerializeField] protected SpriteRenderer m_Target;

        public Sprite[] sprites;

        protected override void OnEnable()
        {
            m_Target.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
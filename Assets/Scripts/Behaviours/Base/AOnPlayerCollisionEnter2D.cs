using UnityEngine;

namespace Game
{
    public abstract class AOnPlayerCollisionEnter2D : MonoBehaviour, IOnCollisionEnter2D
    {
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                OnPlayerEnter(player);
            }
        }

        protected abstract void OnPlayerEnter(Player player);
    }
}
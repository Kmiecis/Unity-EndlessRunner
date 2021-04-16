using UnityEngine;

namespace Game
{
    public abstract class AOnPlayerTriggerEnter2D : MonoBehaviour, IOnTriggerEnter2D
    {
        public void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                OnPlayerEnter(player);
            }
        }

        protected abstract void OnPlayerEnter(Player player);
    }
}
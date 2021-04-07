using UnityEngine;

namespace Game
{
    public abstract class AOnTrigger2D : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTrigger(collision);
        }

        protected abstract void OnTrigger(Collider2D collider);
    }
}
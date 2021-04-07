using UnityEngine;

namespace Game
{
    public abstract class AOnCollide2D : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollide(collision);
        }

        protected abstract void OnCollide(Collision2D collision);
    }
}
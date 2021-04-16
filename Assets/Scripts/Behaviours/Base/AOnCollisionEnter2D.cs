using UnityEngine;

namespace Game
{
    public abstract class AOnCollisionEnter2D : MonoBehaviour
    {
        protected abstract void OnCollisionEnter2D(Collision2D collision);
    }
}
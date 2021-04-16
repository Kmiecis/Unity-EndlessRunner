using UnityEngine;

namespace Game
{
    public abstract class AOnTriggerEnter2D : MonoBehaviour
    {
        protected abstract void OnTriggerEnter2D(Collider2D collision);
    }
}
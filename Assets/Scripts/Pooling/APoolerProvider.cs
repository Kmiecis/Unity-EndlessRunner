using UnityEngine;

namespace Game
{
    public abstract class APoolerProvider : MonoBehaviour
    {
        public abstract Pooler GetPooler();
    }
}
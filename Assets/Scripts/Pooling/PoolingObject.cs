using UnityEngine;

namespace Game
{
    public class PoolingObject : MonoBehaviour
    {
        [HideInInspector] public Pooler pooler;

        public void Return()
        {
            pooler.Return(this);
        }

        public virtual void OnBorrow()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnReturn()
        {
            gameObject.SetActive(false);
        }
    }
}
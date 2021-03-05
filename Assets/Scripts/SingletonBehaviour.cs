using UnityEngine;

namespace Game
{
    public class SingletonBehaviour<T> : MonoBehaviour
        where T : Component
    {
        protected static T m_Instance;

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = FindObjectOfType<T>();
                    if (m_Instance == null)
                    {
                        var host = new GameObject(typeof(T).Name);
                        m_Instance = host.AddComponent<T>();
                    }
                }
                return m_Instance;
            }
        }


        protected virtual void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
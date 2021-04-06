using UnityEngine;

namespace Game
{
    public class UIController : SingletonBehaviour<UIController>
    {
        [SerializeField] protected Canvas m_Canvas;

        public Canvas Canvas => m_Canvas;
    }
}
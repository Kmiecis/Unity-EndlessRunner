using UnityEngine;

namespace Game
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] protected Canvas m_Canvas;

        public Canvas Canvas => m_Canvas;
    }
}
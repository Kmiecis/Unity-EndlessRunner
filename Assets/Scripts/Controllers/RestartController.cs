using Common;
using UnityEngine;

namespace Game
{
    public class RestartController : MonoBehaviour
    {
        [Dependant]
        private UIController m_UIController;

        public GameObject restartScreenPrefab;

        private bool m_IsRestarting;
        private GameObject m_RestartScreen;

        private void Awake()
        {
            Dependencies.Bind(this);
        }

        private void Start()
        {
            m_RestartScreen = Instantiate(restartScreenPrefab, m_UIController.transform);
            m_RestartScreen.SetActive(m_IsRestarting);
        }
    }
}
using UnityEngine;

namespace Game
{
    public class RestartController : SingletonBehaviour<RestartController>
    {
        private static UIController UIController => UIController.Instance;

        public GameObject restartScreenPrefab;

        private bool m_IsRestarting;
        private GameObject m_RestartScreen;

        private void Start()
        {
            m_RestartScreen = Instantiate(restartScreenPrefab, UIController.Canvas.transform);
            m_RestartScreen.SetActive(m_IsRestarting);
        }
    }
}
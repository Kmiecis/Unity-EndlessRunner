using Common;
using UnityEngine;

namespace Game
{
    public class RestartController : DependantBehaviour
    {
        [DependencyInstall, SerializeField]
        protected RestartScreen m_RestartScreenPrefab;

        [DependencyInject("OnRestartScreen")]
        private RestartScreen m_RestartScreen;

        private void OnRestartScreen(RestartScreen restartScreen)
        {
            restartScreen.IsRestarting = false;
        }
    }
}
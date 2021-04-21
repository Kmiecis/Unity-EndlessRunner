using UnityEngine;

namespace Game
{
    public class PlayerController : SingletonBehaviour<PlayerController>
    {
        public GameObject playerPrefab;

        private Player m_Player;

        private void Start()
        {
            m_Player = Instantiate(playerPrefab)
                .GetComponent<Player>();
        }
    }
}
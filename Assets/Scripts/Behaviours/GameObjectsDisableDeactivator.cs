using UnityEngine;

namespace Game
{
    public class GameObjectsDisableDeactivator : AOnDisable
    {
        public GameObject[] gameObjects;

        protected override void OnDisable()
        {
            for (int i = 0; gameObjects != null && i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
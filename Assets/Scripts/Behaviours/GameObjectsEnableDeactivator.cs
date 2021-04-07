using UnityEngine;

namespace Game
{
    public class GameObjectsEnableDeactivator : AOnEnable
    {
        public GameObject[] gameObjects;

        protected override void OnEnable()
        {
            for (int i = 0; gameObjects != null && i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
using UnityEngine;

namespace Game
{
    public class GameObjectsEnableActivator : AOnEnable
    {
        public GameObject[] gameObjects;

        protected override void OnEnable()
        {
            for (int i = 0; gameObjects != null && i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
}
using UnityEngine;

namespace Game
{
    public class GameObjectsActivator : MonoBehaviour
    {
        public GameObject[] gameObjects;

        public void Activate()
        {
            for (int i = 0; gameObjects != null && i < gameObjects.Length; i++)
                gameObjects[i].SetActive(true);
        }

        public void Deactivate()
        {
            for (int i = 0; gameObjects != null && i < gameObjects.Length; i++)
                gameObjects[i].SetActive(false);
        }
    }
}
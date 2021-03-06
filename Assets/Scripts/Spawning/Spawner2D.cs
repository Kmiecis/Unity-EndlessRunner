using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Spawner2D : MonoBehaviour
    {
        public APoolerProvider poolerProvider;

        private CameraController m_CameraController;
        private List<SpawnerObject2D> m_SpawnerObjects = new List<SpawnerObject2D>();

        private void Initialize()
        {
            var spawnerObject = poolerProvider.GetPooler().Borrow() as SpawnerObject2D;
            spawnerObject.transform.position = Vector2.zero;
            m_SpawnerObjects.Add(spawnerObject);
        }

        private void UpdateSpawn()
        {
            var lastObject = m_SpawnerObjects.Last();
            var lastMaxX = lastObject.Max.x;
            var spawnMaxX = m_CameraController.Max.x;

            if (lastMaxX < spawnMaxX)
            {
                var newSpawnerObject = poolerProvider.GetPooler().Borrow() as SpawnerObject2D;
                var newSizeX = newSpawnerObject.Size.x;
                newSpawnerObject.transform.position = new Vector2(lastMaxX + newSizeX, 0.0f);
                m_SpawnerObjects.Add(newSpawnerObject);
            }
        }

        private void UpdateRecycle()
        {
            var firstObject = m_SpawnerObjects.First();
            var firstMaxX = firstObject.Max.x;
            var recycleMinX = m_CameraController.Min.x;

            if (firstMaxX < recycleMinX)
            {
                m_SpawnerObjects.SwapLast(0);
                m_SpawnerObjects.RemoveLast();
                firstObject.Return();
            }
        }

        private void Start()
        {
            m_CameraController = Controllers.Get<CameraController>();

            Initialize();
        }

        private void Update()
        {
            UpdateRecycle();
            UpdateSpawn();
        }
    }
}
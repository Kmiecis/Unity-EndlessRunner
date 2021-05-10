using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Spawner2D : MonoBehaviour
    {
        [Dependant]
        private CameraController m_CameraController;
        
        public APoolerProvider poolerProvider;

        private List<SpawnerObject2D> m_SpawnerObjects = new List<SpawnerObject2D>();

        private void Initialize()
        {
            var spawnerObject = poolerProvider.GetPooler().Borrow() as SpawnerObject2D;
            var spawnerObjectInitialPosition = Vector2.zero;
            var spawnerObjectMinX = spawnerObject.Min.x;
            var spawnMinX = m_CameraController.Min.x;
            while (spawnerObjectMinX > spawnMinX)
            {
                var spawnerObjectSizeX = spawnerObject.Size.x;
                spawnerObjectInitialPosition.x -= spawnerObjectSizeX;
                spawnerObjectMinX -= spawnerObjectSizeX;
            }

            spawnerObject.transform.position = spawnerObjectInitialPosition;
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
                newSpawnerObject.transform.position = new Vector2(lastMaxX + newSizeX * 0.5f, 0.0f);
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
                m_SpawnerObjects.RemoveAt(0);
                firstObject.Return();
            }
        }

        private void Awake()
        {
            Dependencies.Bind(this);
        }

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            UpdateRecycle();
            UpdateSpawn();
        }
    }
}
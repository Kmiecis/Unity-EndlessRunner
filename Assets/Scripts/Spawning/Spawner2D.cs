using Common.Extensions;
using Common.Injection;
using System.Collections.Generic;
using UnityEngine;
using RepoolableSpawnerObject2D = Common.Pooling.IRepoolable<Game.SpawnerObject2D>;

namespace Game
{
    public class Spawner2D : DI_ADependantBehaviour
    {
        [DI_Inject]
        private CameraController m_CameraController;

        [SerializeField]
        private SpawnerObject2DPoolProvider m_PoolProvider;

        private List<RepoolableSpawnerObject2D> m_SpawnerObjects = new List<RepoolableSpawnerObject2D>();

        private void Initialize()
        {
            var spawnerObjectWrapper = m_PoolProvider.Get().Borrow();
            var spawnerObject = spawnerObjectWrapper.Value;
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
            m_SpawnerObjects.Add(spawnerObjectWrapper);
        }

        private void UpdateSpawn()
        {
            var lastObjectWrapper = m_SpawnerObjects.Last();
            var lastObject = lastObjectWrapper.Value;
            var lastMaxX = lastObject.Max.x;
            var spawnMaxX = m_CameraController.Max.x;

            if (lastMaxX < spawnMaxX)
            {
                var newSpawnerObjectWrapper = m_PoolProvider.Get().Borrow();
                var newSpawnerObject = newSpawnerObjectWrapper.Value;
                var newSizeX = newSpawnerObject.Size.x;
                newSpawnerObject.transform.position = new Vector2(lastMaxX + newSizeX * 0.5f, 0.0f);
                m_SpawnerObjects.Add(newSpawnerObjectWrapper);
            }
        }

        private void UpdateRecycle()
        {
            var firstObjectWrapper = m_SpawnerObjects.First();
            var firstObject = firstObjectWrapper.Value;
            var firstMaxX = firstObject.Max.x;
            var recycleMinX = m_CameraController.Min.x;

            if (firstMaxX < recycleMinX)
            {
                m_SpawnerObjects.RemoveAt(0);
                firstObjectWrapper.Dispose();
            }
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
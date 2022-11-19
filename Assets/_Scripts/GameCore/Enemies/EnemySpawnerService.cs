using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.GameCore.Enemies
{
    public class EnemySpawnerService : SceneService<EnemySpawnerService>
    {
        [SerializeField] private Transform[] spawnPoints;

        private EnemyService _enemyService;
        
        internal override void Init()
        {
            _enemyService = ServiceProvider.Instance.Get<EnemyService>(gameObject.scene.name);
            
            _dependencies = new List<Service>()
            {
                _enemyService,
            };
        }

        internal override void Begin()
        {
            SetReady();
        }

        internal override void Dispose()
        {
        }

        public bool SpawnEnemy(GameObject enemyPrefab)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            bool isValid = NavMesh.SamplePosition(spawnPoint.position, out var hit, 1f, NavMesh.AllAreas);
            if (!isValid) return false;
            
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//TODO will change to object pool
            return true;
        }
    }
}

using System.Collections.Generic;
using _Scripts.GameCore.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.GameCore.Enemies
{
    public class EnemySpawnerService : Service<EnemySpawnerService>
    {
        [SerializeField] private Vector3[] spawnPoints;
    
        public Vector3[] SpawnPoints => spawnPoints;
        private EnemyService _enemyService;

        private const float tolerance = 10f;

        internal override void Init()
        {
            _enemyService = ServiceLocator.Instance.Get<EnemyService>();
            
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
            var points = GetFarhestSpawnPoints();

            if (points.Count == 0) return false;

            var spawnPoint = points[Random.Range(0, points.Count)];
            
           /* bool isValid = NavMesh.SamplePosition(spawnPoint, out var hit, 1f, NavMesh.AllAreas);
            if (!isValid) return false;*/
            
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);//TODO will change to object pool
            return true;
        }
        
        private List<Vector3> GetFarhestSpawnPoints()
        {
            var _playerPosition = PlayerManager.Instance.transform.position;
            List<Vector3> farhestSpawnPoints = new List<Vector3>();

            foreach (var spawnPoint in spawnPoints)
            {
                if(Vector3.Distance(_playerPosition, spawnPoint) > tolerance)
                    farhestSpawnPoints.Add(spawnPoint);
            }

            return farhestSpawnPoints;
        }
        
        private void OnDrawGizmos()
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(spawnPoints[i] , 0.5f);
            }
        }
    }
}

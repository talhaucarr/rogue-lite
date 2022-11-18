using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.GameCore.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        
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

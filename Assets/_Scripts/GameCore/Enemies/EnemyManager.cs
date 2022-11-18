using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Utilities;

namespace _Scripts.GameCore.Enemies
{
    public class EnemyManager : AutoSingleton<EnemyManager>
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private EnemySpawner _enemySpawner;
        
        private List<IEntityController> _allEnemies = new List<IEntityController>();

        #region Unity Methods

        private void Start()
        {
            StartTimer();
        }

        private void Update()
        {
            for(int i = 0; i < _allEnemies.Count; i++)
            {
                _allEnemies[i].EnemyUpdate();
            }
        }

        #endregion

        #region Public Methods

        public void RegisterEnemy(IEntityController enemy)
        {
            _allEnemies.Add(enemy);
        }

        public void UnRegisterEnemy(IEntityController enemy)
        {
            _allEnemies.Remove(enemy);
        }

        public bool GetClosestEnemyInRange(Vector3 myPosition, float range, out IEntityController chosenEnemy)
        {
            float closestEnemyDistance = Mathf.Infinity;
            chosenEnemy = null;
            foreach (var enemy in _allEnemies)
            {
                float distance = Vector3.Distance(myPosition, enemy.Transform.position); 
                if(distance > closestEnemyDistance) continue;
                if(distance > range) continue;
                closestEnemyDistance = distance;
                chosenEnemy = enemy;
            }
            return chosenEnemy != null;
        }

        #endregion

        #region Private Methods

        private void StartTimer()
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                _enemySpawner.SpawnEnemy(enemyPrefab);
            }).SetLoops(-1);
        }
        
        #endregion
        
    }
}

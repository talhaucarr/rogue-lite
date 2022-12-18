using System;
using System.Collections.Generic;
using _Scripts.GameCore.Managers;
using _Scripts.HealthSystem;
using _Scripts.RealmSystem;
using DG.Tweening;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace _Scripts.GameCore.Enemies
{
    public class EnemyService : Service<EnemyService>
    {
        private EnemySpawnerService _enemySpawnerService;
        private RealmService _realmService;
        
        private List<IEntityController> _allEnemies = new List<IEntityController>();

        #region Properties

        private float _timeSpentInRealm = 1f;
        private float _spawnDelay = 5f;
        private float _spawnDelayMinCap = 0.5f;
        private RealmData _currentRealmData;

        #endregion

        #region Unity Methods

        internal override void Init()
        {
            _enemySpawnerService = ServiceLocator.Instance.Get<EnemySpawnerService>();
            _realmService = ServiceLocator.Instance.Get<RealmService>();
            _dependencies = new List<Service>()
            {
                _realmService,
            };
        }

        internal override void Begin()
        {
            GetCurrentRealm();
            StartTimer();
            SetReady();
        }

        internal override void Dispose()
        {
        }

        private void Update()
        {
            if(!_isReady)
                return;
            for(int i = 0; i < _allEnemies.Count; i++)
            {
                _allEnemies[i].EnemyUpdate();
            }
            _timeSpentInRealm += Time.deltaTime % 60;
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
        
        public List<IDamagable> GetClosestEnemiesInRange(Vector3 myPosition, float range)
        {
            List<IDamagable> enemiesInRange = new List<IDamagable>();
            foreach (var enemy in _allEnemies)
            {
                float distance = Vector3.Distance(myPosition, enemy.Transform.position); 
                if(distance > range) continue;
                enemiesInRange.Add(enemy.Damagable);
            }
            return enemiesInRange;
        }

        #endregion

        #region Private Methods

        private void StartTimer()
        {
            DOVirtual.DelayedCall(GetRandomDelay(), () =>
            {
                if(_allEnemies.Count >= _currentRealmData.maxEnemies)
                    return;
                
                var enemy = GetRandomEnemyPrefabByPriority();
                var spawnAmount = GetRandomSpawnAmount(enemy);
                _enemySpawnerService.SpawnEnemy(enemy, spawnAmount);
                StartTimer();
            });
        }
        
        private GameObject GetRandomEnemyPrefab()
        {
            return _currentRealmData.realmEnemies[Random.Range(0, _currentRealmData.realmEnemies.Count)].enemyPrefab;
        }
        
        private float GetRandomDelay()
        {
            if (_currentRealmData.harderBetterFasterStronger)
            {
                IncreaseDifficultyByTime();
                return _spawnDelay;
            }
                
            return Random.Range(3, 10);
        }
        
        private int GetRandomSpawnAmount(GameObject enemy)
        {
            foreach (var realmEnemyData in _currentRealmData.realmEnemies)
            {
                if(realmEnemyData.enemyPrefab != enemy) continue;
                return Random.Range(1, realmEnemyData.spawnAmount);
            }
            Debug.LogError("Enemy not found in realm data");
            return -1;
        }

        private void IncreaseDifficultyByTime()
        {
            if (!(_timeSpentInRealm > 10)) return;//if time is less than 10 seconds, do nothing
            
            _timeSpentInRealm = 0;
            _spawnDelay -= 0.5f;//decrease spawn delay by 0.5 seconds
            if(_spawnDelay < _spawnDelayMinCap)
                _spawnDelay = _spawnDelayMinCap;
        }

        private GameObject GetRandomEnemyPrefabByPriority()
        {
            var enemies = _currentRealmData.realmEnemies;
            var totalWeight = 0;
            foreach (var enemy in enemies)
            {
                totalWeight += enemy.spawnWeight;
            }
            var randomWeight = Random.Range(0, totalWeight);
            foreach (var enemy in enemies)
            {
                if (randomWeight < enemy.spawnWeight)
                {
                    return enemy.enemyPrefab;
                }
                randomWeight -= enemy.spawnWeight;
            }
            return null;
        }

        private void GetCurrentRealm()
        {
           _currentRealmData = _realmService.GetRealmData("ForestRuins");//TODO will be changed
        }
        
        #endregion
        
    }
}

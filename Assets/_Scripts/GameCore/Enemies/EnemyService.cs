using System;
using System.Collections.Generic;
using _Scripts.GameCore.Managers;
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

        public EnemySpawnerService EnemySpawner => _enemySpawnerService;
        
        private float _timeSpentInRealm = 1f;
        private float _minDelayBetweenSpawns = 0.8f;

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
            _timeSpentInRealm += Time.deltaTime;
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
            DOVirtual.DelayedCall(GetRandomDelay(), () =>
            {
                _enemySpawnerService.SpawnEnemy(GetRandomEnemyPrefabByPriority());
                StartTimer();
            });
        }
        
        private GameObject GetRandomEnemyPrefab()
        {
            var realmData = GetCurrentRealm();
            return realmData.realmEnemies[Random.Range(0, realmData.realmEnemies.Count)].enemyPrefab;
        }
        
        private float GetRandomDelay()
        {
            var realmData = GetCurrentRealm();

            if (realmData.harderBetterFasterStronger)
            {
                //var delay = _minDelayBetweenSpawns * (5f / (_timeSpentInRealm / 10f));
                var delay = 50000f / (Time.time + 300) / 30;
                if(delay <= _minDelayBetweenSpawns)
                    delay = _minDelayBetweenSpawns;
                Debug.Log($"Delay is {delay}");
                return delay;
            }
                
            return Random.Range(3, 6);
        }

        
        private GameObject GetRandomEnemyPrefabByPriority()
        {
            var realmData = GetCurrentRealm();
            var enemies = realmData.realmEnemies;
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

        private RealmData GetCurrentRealm()
        {
           return _realmService.GetRealmData("ForestRuins");//TODO will be changed
        }
        
        #endregion
        
    }
}

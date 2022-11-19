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
    public class EnemyService : SceneService<EnemyService>
    {
        private EnemySpawnerService _enemySpawnerService;
        
        private List<IEntityController> _allEnemies = new List<IEntityController>();

        #region Properties

        public EnemySpawnerService EnemySpawner => _enemySpawnerService;

        #endregion

        #region Unity Methods

        internal override void Init()
        {
            _enemySpawnerService = ServiceProvider.Instance.Get<EnemySpawnerService>(gameObject.scene.name);
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
            DOVirtual.DelayedCall(Random.Range(1f, 3f), () =>
            {
                _enemySpawnerService.SpawnEnemy(GetRandomEnemyPrefab());
            }).SetLoops(-1);
        }
        
        private GameObject GetRandomEnemyPrefab()
        {
            var realmData = GetCurrentRealm();
            return realmData.realmEnemies[Random.Range(0, realmData.realmEnemies.Count)].enemyPrefab;
        }

        private RealmData GetCurrentRealm()
        {
           return GameManager.Instance.GetRealmData("ForestRuins");
        }
        
        #endregion
        
    }
}

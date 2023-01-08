using System;
using _Scripts.GameCore.Enemies;
using _Scripts.GameCore.ProjectileSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.Minions.AttackSystem
{
    public class MinionAttackController : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField] private GameObject _projectilePrefab;

        #endregion
        
        #region Private Variables
        
        private EnemyService _enemyService;
        private StatSettings _statSettings;
        private float _attackTimer = 20;
        private float _attackSpeed;

        #endregion
        
        #region Public Variables
        
        #endregion
        
        #region Unity Methods

        private void Start()
        {
            _enemyService = ServiceLocator.Instance.Get<EnemyService>();
        }

        private void Update()
        {
            _attackTimer += Time.deltaTime;
            if (_attackTimer >= (20f / (1 + _attackSpeed)))
            {
                if(!Attack()) return;
                _attackTimer = 0;
            }
        }

        #endregion

        #region Public Methods

        public void Setup(StatSettings statSettings)
        {
            _statSettings = statSettings;
            _attackSpeed = _statSettings.GetStat(StatKey.AttackSpeed);
        }
        
        #endregion
        
        #region Private Methods
        
        private bool Attack()
        {
            _enemyService.GetClosestEnemyInRange(transform.position, _statSettings.GetStat(StatKey.AttackRange), out var enemy);
            if (enemy == null) return false;
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().Setup(enemy.Transform, 30, _statSettings.GetStat(StatKey.Damage));
            return true;
        }

        #endregion
    }
}

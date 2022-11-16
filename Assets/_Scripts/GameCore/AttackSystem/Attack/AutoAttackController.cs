using _Scripts.AnimationSystem;
using _Scripts.GameCore.AttackSystem.Interfaceses;
using _Scripts.HealthSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackSystem.Attack
{
    public class AutoAttackController : MonoBehaviour, IAttack
    {
        [BHeader("Attack Type")]
        [SerializeField] private string attackName;
        [SerializeField] private GameObject attackPrefab;

        [Space(20)][BHeader("References")]
        [SerializeField] private AnimationController _animationController;
        private StatSettings _statSettings;
        private float _attackTimer = 0;
        private float _attackSpeed; // duration = 20 / 3 + attackSpeed

        public void Setup(StatSettings statSettings)
        {
            _statSettings = statSettings;
            _attackSpeed = statSettings.GetStat(StatKey.AttackSpeed);
        }

        private void FixedUpdate()
        {
            _attackTimer += Time.fixedDeltaTime;
            if (_attackTimer >= (20f / (1 + _attackSpeed)))
            {
                if (!Attack()) return;
                
                _animationController.CastSpell();
                _attackTimer = 0;
            }
        }

        public bool Attack()
        {
            if(!EnemyManager.Instance.GetClosestEnemyInRange(transform.position, _statSettings.GetStat(StatKey.AttackRange), out var enemy)) return false;
            if (!enemy.Transform.TryGetComponent<IDamagable>(out var damagable)) return false;
            damagable.DealDamage(_statSettings.GetStat(StatKey.Damage));
            if(attackPrefab) Instantiate(attackPrefab, enemy.Transform.position, Quaternion.identity);
            return true;
        }
    }
}

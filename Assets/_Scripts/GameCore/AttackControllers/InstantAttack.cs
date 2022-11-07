using _Scripts.AttackSystem;
using _Scripts.AttackSystem.Attack;
using _Scripts.HealthSystem;
using UnityEngine;

namespace _Scripts.GameCore.AttackControllers
{
    [CreateAssetMenu(fileName = "New Instant Attack", menuName = "ScriptableObjects/AttackSystem/InstantAttack")]
    public class InstantAttack : AttackBase
    {
        public override bool Attack(AttackData attackData)
        {
            if(!EnemyManager.Instance.GetClosestEnemyInRange(attackData.myTransform.position, _stats.AttackRange, out var enemy)) return false;
            if (!enemy.Transform.TryGetComponent<IDamagable>(out var damagable)) return false;
            damagable.DealDamage(_stats.Damage);
            return true;
        }
    }
}

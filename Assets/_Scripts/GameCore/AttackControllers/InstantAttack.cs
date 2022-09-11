using System;
using System.Diagnostics;
using _Scripts.HealthSystem;
using _Scripts.StatSystem;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace _Scripts.AttackSystem
{
    [CreateAssetMenu(fileName = "New Attack", menuName = "ScriptableObjects/AttackSystem/Attack")]
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

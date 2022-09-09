using System;
using System.Diagnostics;
using _Scripts.HealthSystem;
using _Scripts.StatSystem;
using UnityEngine;

namespace _Scripts.AttackSystem
{
    [CreateAssetMenu(fileName = "New Attack", menuName = "ScriptableObjects/AttackSystem/Attack")]
    public class PlayerAttack : AttackBase
    {
        public override void Attack(AttackData attackData)
        {
            _attackData = attackData;
            
            if (!Physics.Raycast(_attackData.target.position, _attackData.target.forward, out var hit, _attackData.range)) return;
        
            if (hit.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.DealDamage(_attackData.damage);
            }
        }
    }
}

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
        protected override void RangedAttack(StatSettings settings, Vector3 target)
        {
            if (!Physics.Raycast(_playerTransform.position, _playerTransform.forward, out var hit, _statSettings.AttackRange)) return;
        
            if (hit.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.DealDamage(_statSettings.Damage);
            }
        }
    }
}
